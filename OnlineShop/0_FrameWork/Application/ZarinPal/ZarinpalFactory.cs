﻿
using _0_FrameWork.Application.ZarinPal;
using RestSharp;
using RestSharp.Serializers.Json;

namespace _0_Framework.Application.ZarinPal
{
    public class ZarinPalFactory : IZarinPalFactory
    {
        /*private readonly IConfiguration _configuration;*/

        public string Prefix { get; set; } = "sandbox";
        private string MerchantId { get;}
        
        /*public ZarinPalFactory(IConfiguration configuration)
        {
            _configuration = configuration;
            Prefix = _configuration.GetSection("payment")["method"];
            MerchantId= _configuration.GetSection("payment")["merchant"];
        }*/

        public PaymentResponse CreatePaymentRequest(string amount, string mobile, string email, string description,
             long orderId)
        {
            amount = amount.Replace(",", "");
            var finalAmount = int.Parse(amount);
            /*var siteUrl = _configuration.GetSection("payment")["siteUrl"];*/
            var siteUrl = "https://localhost:7248/";

            var client = new RestClient($"https://{Prefix}.zarinpal.com/pg/rest/WebGate/PaymentRequest.json");
            var request = new RestRequest(Method.Post.ToString());
            request.AddHeader("Content-Type", "application/json");
            var body = new PaymentRequest
            {
                Mobile = mobile,
                CallbackURL = $"{siteUrl}/Checkout?handler=CallBack&oId={orderId}",
                Description = description,
                Email = email,
                Amount = finalAmount,
                MerchantID = MerchantId
            };
            request.AddJsonBody(body);
            var response = client.Execute(request);
            var jsonSerializer = new RestSharp.Serializers.Json.SystemTextJsonSerializer();
            return jsonSerializer.Deserialize<PaymentResponse>(response);
        }

        public VerificationResponse CreateVerificationRequest(string authority, string amount)
        {
            var client = new RestClient($"https://{Prefix}.zarinpal.com/pg/rest/WebGate/PaymentVerification.json");
            var request = new RestRequest(Method.Post.ToString());
            request.AddHeader("Content-Type", "application/json");

            amount = amount.Replace(",", "");
            var finalAmount = int.Parse(amount);

            request.AddJsonBody(new VerificationRequest
            {
                Amount = finalAmount,
                MerchantID = MerchantId,
                Authority = authority
            });
            var response = client.Execute(request);
            var jsonSerializer = new RestSharp.Serializers.Json.SystemTextJsonSerializer();
            return jsonSerializer.Deserialize<VerificationResponse>(response);
        }
    }
}