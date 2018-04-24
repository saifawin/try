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
    public class PaymentBIL
    {
        PaymentDAL paymentDAL = null;
        public PaymentBIL()
        {
            paymentDAL = new PaymentDAL();
        }

        #region insert
        public long insert(Payment payment)
        {
            long result = 0;

            try
            {
                result = paymentDAL.insert(payment);
                if (result <= 0) throw new Exception("update failed!");
            }
            catch
            {
                throw;
            }
            return result;
        }
        #endregion insert

        #region update
        public bool update(Payment payment)
        {
            bool result = false;

            try
            {
                result = paymentDAL.update(payment);
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
                result = paymentDAL.delete(id);
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
        public Payment getById(int id)
        {
            Payment payment = null;
            try
            {
                payment = paymentDAL.getById(id);
            }
            catch
            {
                throw;
            }
            return payment;
        }
        #endregion getById

        #region getAll
        public IEnumerable<Payment> getAll()
        {
            IEnumerable<Payment> payments = null;
            try
            {
                payments = paymentDAL.getAll();
            }
            catch
            {
                throw;
            }
            return payments;
        }
        #endregion getAll

        #region update
        public bool update(int userId, string cardNo)
        {
            bool result = false;
            try
            {
                IEnumerable<Payment> payments = paymentDAL.getPaymentByUserId(userId);
                var user = new UsersDAL().getById(userId);
                string cNo = user.CardNo == null ? string.Empty : user.CardNo;

                if (cNo == cardNo)
                {
                    foreach (var payment in payments)
                    {
                        payment.StatusId = new GeneralDAL().getByCodeAndTypeCode("PY", "PAYMENT").Id;
                        result = paymentDAL.update(payment);

                        if (result)
                        {
                            BookingDAL bookingDAL = new BookingDAL();
                            var bookings = bookingDAL.getByUserId(userId);
                            if (bookings != null)
                                result = new BookingBIL().updateCarparkByStatus((int)bookings.BuildingParkId, "AV");

                        }
                    }
                }
                else
                {
                    throw new Exception("Invalide creadit card no.");
                }
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return result;
        }
        #endregion update

        #region getTotalPayment
        public decimal getTotalPayment(int userId)
        {
            decimal totalPayment = 0;
            try
            {
                totalPayment = paymentDAL.getTotalPayment(userId);
            }
            catch
            {
                throw;
            }
            return totalPayment;
        }
        #endregion getTotalPayment

        #region getHours
        public string getHours(int userId)
        {
            string hhmm = string.Empty;
            try
            {
                hhmm = paymentDAL.getHours(userId);
            }
            catch
            {
                throw;
            }
            return hhmm;
        }
        #endregion getHours

    }
}
