using Microsoft.AspNetCore.Mvc;
using Stripe.Checkout;

[Route("api/payment")]
[ApiController]
public class PaymentController : ControllerBase
{
    [HttpPost("create-product-session")]
    public IActionResult Create([FromBody] ProductPaymentRequest req)
    {
        var service = new SessionService();

        var session = service.Create(new SessionCreateOptions
        {
            PaymentMethodTypes = new List<string> { "card" },
            Mode = "payment",

            LineItems = req.Items.Select(i => new SessionLineItemOptions
            {
                Quantity = i.Quantity,
                PriceData = new SessionLineItemPriceDataOptions
                {
                    Currency = "usd",
                    UnitAmount = (long)(i.Price * 100),
                    ProductData = new SessionLineItemPriceDataProductDataOptions
                    {
                        Name = i.Name
                    }
                }
            }).ToList(),

            SuccessUrl = "http://localhost:5173/payment-success",
            CancelUrl = "http://localhost:5173/payment-cancel"
        });

        return Ok(new { url = session.Url });
    }
}

public class ProductPaymentRequest
{
    public List<ProductItem> Items { get; set; }
}

public class ProductItem
{
    public string Name { get; set; }
    public decimal Price { get; set; }
    public int Quantity { get; set; }
}