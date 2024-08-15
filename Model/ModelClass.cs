using System.Runtime.Versioning;

namespace ApiGeneration.Model
{

    public class User
    {
        public int statusCode { get; set; }
        public string email { get; set; }
        public string fName { get; set; }
        public string lName { get; set; }
        public string pImage { get; set; }
        public int userId { get; set; }
    }
    public class UserLogin
    {
        public string email { get; set; }
        public string password { get; set; }
    }
    public class UserDetails
    {
        public int statusCode { get; set; }
        public int userId { get; set; }
        public string email { get; set; }
        public string fName { get; set; }
        public string lName { get; set; }
        public string pImage { get; set; }
        public string vehicleNo { get; set; }
        public string area { get; set; }
        public string city { get; set; }
        public int pincode { get; set; }
        public string phone { get; set; }
        public string vehicleName { get; set; }
    }

    public class UserDetailsLogin
    {
        public string email { get; set; }
        public string password { get; set; }
    }

    public class UserDetailsWithId
    {
        public int statusCode { get; set; }
        public int userId { get; set; }
        public string email { get; set; }
        public string fName { get; set; }
        public string lName { get; set; }
        public string pImage { get; set; }
        public string vehicleNo { get; set; }
        public string area { get; set; }
        public string city { get; set; }
        public int pincode { get; set; }
        public string phone { get; set; }
        public string vehicleName { get; set; }
    }

    public class ServiceTimings
    {
        public int statusCode { get; set; }
        public int serviceId { get; set; }
        public int userId { get; set; }
        public DateTime Timings { get; set; }
        public string DateAndTime { get; set; }
    }

    public class AddServiceTime

    {
        public int userId { get; set; }
        public DateTime Timings { get; set; }
        public string DateAndTime { get; set; }
    }

    public class AddUserDetails
    {
        public string email { get; set; }
        public string password { get; set; }
        public string fName { get; set; }
        public string lName { get; set; }
        public string pImage { get; set; }
        public string vehicleNo { get; set; }
        public string area { get; set; }
        public string city { get; set; }
        public int pincode { get; set; }
        public string phone { get; set; }
        public string vehicleName { get; set; }
    }

    public class Confirmations
    {
        public int userId { get; set; }
        public int serviceId { get; set; }
        public string status { get; set; }
        public string message { get; set; }
    }

    public class ConfirmationsListUser
    {
        public int statusCode { get; set; }
        public int scheduleId { get; set; }
        public int userId { get; set; }
        public int serviceId { get; set; }
        public string status { get; set; }
        public string message { get; set; }
    }

    public class UserDetailsSearch
    {
        public int statusCode { get; set; }
        public int userId { get; set; }
        public string email { get; set; }
        public string fName { get; set; }
        public string lName { get; set; }
        public string pImage { get; set; }
        public string vehicleNo { get; set; }
        public string area { get; set; }
        public string city { get; set; }
        public int pincode { get; set; }
        public string phone { get; set; }
        public string vehicleName { get; set; }
    }

    public class Image {
        public int statusCode { get; set; }
        public string Img { get; set; }
    }

    public class Products
    {
        public int statusCode { get; set; }
        public int productId { get; set; }
        public string productName { get; set; }
        public int productPrice { get; set; }
        public string productDescription { get; set; }
        public string productImage { get; set; }
        public int productRating { get; set; }
    }

}
