namespace oop_practice_9
{
   
        public class CreditCard
        {
            public string OwnerName { get; init; }
            public long CardNumber { get; init; }
            public DateTime Date { get; init; }
            public ushort CVV { get; init; }

            public CreditCard(string ownerName, long cardNumber, DateTime date, ushort cVV)
            {
                OwnerName = ownerName;
                CardNumber = cardNumber;
                Date = date;
                CVV = cVV;
            }
        }
}
