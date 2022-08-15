namespace Domain.Entities;

public class Sale : EntityBase, IEntityBase
{
    private int quantity;
    private decimal totalPrice;
    private decimal unitPrice;
    public DateTime Date { get; set; }

    public Customer Customer { get; set; }

    public Employee Employee { get; set; }

    public Product Product { get; set; }

    public decimal UnitPrice
    {
        get { return this.unitPrice; }
        set
        {
            this.unitPrice = value;
            UpdateTotalPrice();
        }
    }
   
    public int Quantity
    {
        get { return this.quantity; }
        set
        {
            this.quantity = value;
            UpdateTotalPrice();
        }
    }
    
    public decimal TotalPrice
    {
        get { return this.totalPrice; }
        private set { this.totalPrice = value; }
    }

    private void UpdateTotalPrice() =>    
       this.totalPrice = this.unitPrice * this.quantity;
    
}
