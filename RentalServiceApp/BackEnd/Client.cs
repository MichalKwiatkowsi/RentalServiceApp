using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RentalServiceApp.FrontEnd;

namespace RentalServiceApp.BackEnd
{
    public class Client
    {
        public Client(int clientId, string fullName, DateTime drivingLicenceDate)
        {
            ClientId = clientId;
            FullName = fullName;
            DrivingLicenceIssueDate = drivingLicenceDate;

        }
        public int ClientId { get; set; }
        public string FullName { get; set; }
        public DateTime DrivingLicenceIssueDate { get; set; }
    }
}
