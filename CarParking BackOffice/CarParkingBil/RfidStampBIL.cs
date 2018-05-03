using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using CarParkingData;
using CarParkingDAL;

namespace CarParkingBIL
{
    public class RfidStampBIL
    {
        RfidStampDAL rfidstampDAL = null;
        public RfidStampBIL()
        {
            rfidstampDAL = new RfidStampDAL();
        }

        #region insert
        public long insert(RfidStamp rfidstamp)
        {
            long result = 0;

            try
            {
                //ตรวจสอบดูว่ามี RFID ถูกตั้งค่าไว้ใน Config หรือไม่ ถ้ายังไม่มีไม่ให้ INSERT
                var rfidCon=new RfidConfigDAL().getByUID(rfidstamp.UID);
                if (rfidCon != null)
                {
                    int count = rfidstampDAL.getByStatus(rfidstamp.UID, "IN");
                    if (count > 0)
                    {
                        rfidstamp.Status = "OUT";
                    }
                    else
                    {
                        rfidstamp.Status = "IN";
                    }

                    rfidstamp.Date = DateTime.Now;
                    result = rfidstampDAL.insert(rfidstamp);
                    if (result <= 0) throw new Exception("update failed!");
                    else
                    {
                        //ส่วนของการคำนวณค่าจอดรถ
                        if (rfidstamp.Status == "OUT")
                        {
                            decimal payment = rfidstampDAL.getPayment(rfidstamp.UID);
                            Payment pay = new Payment();
                            pay.Total = payment;
                            pay.Date = DateTime.Now;
                            pay.StatusId = new GeneralDAL().getByCodeAndTypeCode("NPY", "PAYMENT").Id;
                            pay.UserId = new UsersDAL().getUserByUID(rfidstamp.UID).Id;

                            new PaymentBIL().insert(pay);

                            // สั่งให้เครียร์ค่า เลขทะเบียนรถ
                            RfidConfigDAL rfidConfigDAL = new RfidConfigDAL();
                            var rfidConfig = rfidConfigDAL.getByUID(rfidstamp.UID);
                            rfidConfig.CarNo = string.Empty;
                            rfidConfigDAL.update(rfidConfig);
                        }
                    }
                }
            }
            catch
            {
                throw;
            }
            return result;
        }
        #endregion insert

        #region update
        public bool update(RfidStamp rfidstamp)
        {
            bool result = false;

            try
            {
                result = rfidstampDAL.update(rfidstamp);
                if (!result) throw new Exception("update failed!");
            }
            catch
            {
                throw;
            }

            return result;
        }
        #endregion update

        #region delete
        public bool delete(int id)
        {
            bool result = false;
            try
            {
                result = rfidstampDAL.delete(id);
                if (!result) throw new Exception("delete failed!");
            }
            catch
            {
                throw;
            }
            return result;
        }
        #endregion delete

        #region getById
        public RfidStamp getById(int id)
        {
            RfidStamp rfidstamp = null;
            try
            {
                rfidstamp = rfidstampDAL.getById(id);
            }
            catch
            {
                throw;
            }
            return rfidstamp;
        }
        #endregion getById

        #region getAll
        public IEnumerable<RfidStamp> getAll()
        {
            IEnumerable<RfidStamp> rfidstamps = null;
            try
            {
                rfidstamps = rfidstampDAL.getAll();
            }
            catch
            {
                throw;
            }
            return rfidstamps;
        }
        #endregion getAll
    }
}
