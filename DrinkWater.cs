namespace HabitLogger
{
    internal class DrinkWater
    {
        public int Id { get; set; }
        public DateTime Date {  get; set; }
        public int Quantity { get; set; }
        public override string ToString() => $"{Id}, {Date.ToShortDateString()}, {Quantity}"; 
    }
}
