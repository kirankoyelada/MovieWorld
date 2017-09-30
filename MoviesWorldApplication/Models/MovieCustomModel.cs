using Stripe;
namespace MoviesWorldApplication.Models
{
    public class MovieCustomModel
    {
        public int movieID { get; set; }
        public string tokenID { get; set; }
        public string chargeCard(string tokenID, int amount, string description)
        {
            string result = string.Empty;
            var chargeOptions = new StripeChargeCreateOptions()
            {
                Amount = amount,
                Currency = "USD",
                Description = description,
                SourceTokenOrExistingSourceId = tokenID
            };
            var chargeService = new StripeChargeService("Place your API Key :)");
            try
            {
                StripeCharge strCharge = chargeService.Create(chargeOptions);
                result = strCharge.Status;
            }
            catch (StripeException ex)
            {
                result = ex.InnerException.Message.ToString();
            }
            return result;
        }
    }
}