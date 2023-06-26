using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class HoMIRepository
    {
        private Hotel_ManagementContext context;

        public HoMIRepository( Hotel_ManagementContext context )
        {
            this.context = context;
        }
        #region GetAllCust
        public List<Customer> GetAllCustomerDetails()
        {
            List<Customer> customerlist = new List<Customer>();
            try
            {
                customerlist = (from customer in context.Customers orderby customer.CId select customer).ToList();
            }
            catch (Exception)
            {
                customerlist = null;
            }
            return customerlist;
        }
        #endregion

        #region GetAllRoom
        public List<RoomDetail> GetAllRoomDetails()
        {
            List<RoomDetail> roomList = new List<RoomDetail>();
            try
            {
                roomList = (from roomdetails in context.RoomDetails orderby roomdetails.RId select roomdetails).ToList();
            }
            catch (Exception)
            {
                roomList = null;
            }
            return roomList;
        }
        #endregion

        #region GetAllBooking
        public List<BookingDetail> GetAllBookDetails()
        {
            List<BookingDetail> bookList = new List<BookingDetail>();
            try
            {
                bookList = (from bookdetails in context.BookingDetails orderby bookdetails.BId select bookdetails).ToList();
            }
            catch (Exception)
            {
                bookList = null;
            }
            return bookList;
        }
        #endregion

        #region GetbyIdCust
        public Customer GetCustomerDetails(string cId)
        {
            Customer CustomerDetails = new Customer();

            try
            {
                CustomerDetails = context.Customers
                                        .Where(c => c.CId == cId)
                                        .FirstOrDefault();
            }
            catch (Exception)
            {
                CustomerDetails = null;
            }
            return CustomerDetails;
        }
        #endregion

        #region GetbyIdRoom
        public RoomDetail GetRoomDetails(string rId)
        {
            RoomDetail roomDetails = new RoomDetail();

            try
            {
                roomDetails = context.RoomDetails
                                        .Where(c => c.RId == rId)
                                        .FirstOrDefault();
            }
            catch (Exception)
            {
                roomDetails = null;
            }
            return roomDetails;
        }
        #endregion

        #region GetbyIdBook
        public BookingDetail GetBookDetails(int bId)
        {
           BookingDetail bookDetails = new BookingDetail();

            try
            {
                bookDetails = context.BookingDetails
                                        .Where(c => c.BId == bId)
                                        .FirstOrDefault();
            }
            catch (Exception)
            {
                bookDetails = null;
            }
            return bookDetails;
        }
        #endregion

        #region addcust
        public bool AddCustDetails(Customer custObj)
        {
            bool status = false;
            try
            {
                context.Customers.Add(custObj);
                context.SaveChanges();
                status = true;
            }
            catch (Exception)
            {
                status = false;
            }
            return status;

        }
        #endregion

        #region addroom
        public bool AddRoomDetails(RoomDetail roomObj)
        {
            bool status = false;
            try
            {
                context.RoomDetails.Add(roomObj);
                context.SaveChanges();
                status = true;
            }
            catch (Exception)
            {
                status = false;
            }
            return status;

        }
        #endregion

        #region POST:AddBooking
        public bool AddAllBookingDetails(BookingDetail bookObj)
        {
            bool status = false;
            try
            {
                context.BookingDetails.Add(bookObj);
                context.SaveChanges();
                status = true;
            }
            catch (Exception)
            {
                status = false;
            }
            return status;

        }
        #endregion

        #region updatecustomerdetails       
        public bool UpdateCustomerDetails(Customer custObj)
        {
            bool status = false;
            try
            {
                var custD = (from customer in context.Customers
                             where customer.CId == custObj.CId
                             select customer).FirstOrDefault<Customer>();
                if (custD != null)
                {
                    custD.CId = custObj.CId;
                    custD.CName = custObj.CName;
                    custD.Age = custObj.Age;
                    custD.MNo = custObj.MNo;
                    custD.Address = custObj.Address;
                    
                    context.SaveChanges();
                    status = true;
                }
            }
            catch (Exception)
            {
                status = false;
            }
            return status;
        }
        #endregion

        #region updateroomdetails
        public bool UpdateRoomDetails(RoomDetail roomObj)
        {
            bool status = false;
            try
            {
                var roomD = (from roomdetail in context.RoomDetails
                             where roomdetail.RId == roomObj.RId
                             select roomdetail).FirstOrDefault<RoomDetail>();
                if (roomD != null)
                {
                   // roomD.RId = roomObj.RId;
                    roomD.RType = roomObj.RType;
                    roomD.RSize = roomObj.RSize;
                    roomD.RPrice = roomObj.RPrice;
                    roomD.Facility = roomObj.Facility;
                    roomD.Description = roomObj.Description;
                    roomD.Cancellation = roomObj.Cancellation;
                   // roomD.Image= roomObj.Image;
                    
                    
                   // roomD.Duration = roomObj.Duration;
                    context.SaveChanges();
                    status = true;
                }
            }
            catch (Exception)
            {
                status = false;
            }
            return status;
        }
        #endregion

        #region updatebookingdetails
      
        public bool UpdateBookingDetails(BookingDetail bookObj)
        {
            bool status = false;
            try
            {
                var bookD = (from bookdetail in context.BookingDetails
                             where bookdetail.BId == bookObj.BId
                             select bookdetail).FirstOrDefault<BookingDetail>();
                if (bookD != null)
                {
                    bookD.BId = bookObj.BId;
                    //bookD.RId = bookObj.RId;                  
                   // bookD.RSize = bookObj.CId;
                   // bookD.CName = bookObj.CName;
                    bookD.InDate = bookObj.InDate;
                    bookD.OutDate = bookObj.OutDate;
                    bookD.Facility = bookObj.Facility;
                    bookD.Cancellation = bookObj.Cancellation;
                   // bookD.Status = bookObj.Status;
                    context.SaveChanges();
                    status = true;
                }
            }
            catch (Exception)
            {
                status = false;
            }
            return status;
        }
        #endregion

        #region delete customer
        public int DeleteCustomer(string cId)
        {
            int status = -1;
            Customer custObj;
            try
            {
                custObj = context.Customers.Find(cId);
                if (custObj != null)
                {
                    context.Customers.Remove(custObj);
                    context.SaveChanges();
                    status = 1;
                }
                else
                {
                    status = -1;
                }
            }
            catch (Exception)
            {
                status = -99;
            }
            return status;
        }
        #endregion

        #region deleteroom
        public int DeleteRoom(string rId)
        {
            int status = -1;
            RoomDetail roomObj;
            try
            {
                roomObj = context.RoomDetails.Find(rId);
                if (roomObj != null)
                {
                    context.RoomDetails.Remove(roomObj);
                    context.SaveChanges();
                    status = 1;
                }
                else
                {
                    status = -1;
                }
            }
            catch (Exception)
            {
                status = -99;
            }
            return status;
        }
        #endregion

        #region cancel booking
        public int CancelBooking(int bId)
        {
            int status = -1;
            BookingDetail bookObj;
            try
            {
                bookObj = context.BookingDetails.Find(bId);
                if (bookObj != null)
                {
                    context.BookingDetails.Remove(bookObj);
                    context.SaveChanges();
                    status = 1;
                }
                else
                {
                    status = -1;
                }
            }
            catch (Exception)
            {
                status = -99;
            }
            return status;
        }
        #endregion
    }
}
