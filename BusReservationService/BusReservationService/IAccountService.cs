using System.Runtime.Serialization;
using System.ServiceModel;

namespace BusReservationService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract]
    public interface IAccountService
    {
        [OperationContract]
        string Login(string username, string password);

        [OperationContract]
        string Register(User user);
    }

    // Use a data contract as illustrated in the sample below to add composite types to service operations.
    // You can add XSD files into the project. After building the project, you can directly use the data types defined there, with the namespace "BusReservationService.ContractType".
    [DataContract]
    public class User
    {
        string email;
        string username;
        string password;

        public User(string email, string username, string password)
        {
            this.email = email;
            this.username = username;
            this.password = password;
        }

        public User() {  }

        [DataMember]
        public string UserName
        {
            get { return username; }
            set { username = value; }
        }

        [DataMember]
        public string Email
        {
            get { return email; }
            set { email = value; }
        }

        [DataMember]
        public string Password
        {
            get { return password; }
            set { password = value; }
        }
    }
}
