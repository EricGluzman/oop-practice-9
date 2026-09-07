using oop_practice_9.Exceptions;
using System.ComponentModel.Design;

namespace oop_practice_9.UserGroup
{
    
        public class Employment
        {
            #region Properties
            public string CompanyName { get; init; }
            public DateTime StartDate { get; init; }
            public DateTime EndDate { get; private set; }
            public bool IsCurrent { get; private set; }
            #endregion
            #region Ctor
            public Employment(string companyName, DateTime startDate, DateTime endDate)
            {
                CompanyName = companyName;
                StartDate = startDate;
                EndDate = endDate;
                IsCurrent = false;
            }
            public Employment(string companyName, DateTime startDate)
            {
                CompanyName = companyName;
                StartDate = startDate;
                EndDate = DateTime.Now;
                IsCurrent = true;
            }

            public void EndJob(bool b)
            {
                if (!b && IsCurrent)
                {
                    IsCurrent = false;
                    EndDate = DateTime.Now;
                }
                else throw new IsCurrentWorkException("Cannot Change The Current Work State, if before change the job was already over");
            }
            #endregion
        }
}
