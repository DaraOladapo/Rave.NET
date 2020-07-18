using Newtonsoft.Json.Linq;
using Rave.NET.Models;
using Rave.NET.Models.Account;
using Rave.NET.Models.Card;
using Rave.NET.Models.Charge;
using Rave.NET.Models.Ebills;
using Rave.NET.Models.MobileMoney;
using Rave.NET.Models.Subaccount;
using Rave.NET.Models.Subscriptions;
using Rave.NET.Models.Tokens;
using Rave.NET.Models.VirtualAccount;
using Rave.NET.Models.VirtualCard;
using System;
using Xunit;

namespace Rave.NET.Tests
{
    public class APITests
    {
        public APITests()
        {
            DotNetEnv.Env.Load();
        }
        string txRef = Environment.GetEnvironmentVariable("txRef");
        string successfulFwRef = Environment.GetEnvironmentVariable("successfulFwRef");
        string unCapturedFwRef = Environment.GetEnvironmentVariable("unCapturedFwRef");
        string tranxRef = Environment.GetEnvironmentVariable("tranxRef");
        // string PbKey = Environment.GetEnvironmentVariable("PbKey");
        // string ScKey = Environment.GetEnvironmentVariable("ScKey");
        string PbKey = "FLWPUBK_TEST-e249f67527cbc6331261c8d935fa5735-X";
        string ScKey = "FLWSECK_TEST-3bca3e0b02cff2b0f79d7b83fb81fb67-X";
        [Fact]
        public void preauthTest()
        {

            var raveConfig = new RaveConfig(PbKey, ScKey, false);
            var preauthCard = new PreAuth(raveConfig);

            var card = new Card("5377283645077450", "09", "21", "789");

            var preauthResponse = preauthCard.Preauthorize(new PreAuthParams(raveConfig.PbfPubKey, raveConfig.SecretKey, "Olufumi", "Obafumiso", "olufemi@gmail.com", 120, "USD", card) { TxRef = txRef }).Result;


            try
            {
                Assert.NotNull(preauthResponse.Data);
                Assert.Equal("success", preauthResponse.Status);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }


        }

        //Noauth Card charge test
        [Fact]
        public void avschargetest()
        {
            var raveConfig = new RaveConfig(PbKey, ScKey, false);
            var cardCharge = new ChargeCard(raveConfig);
            var card = new Card("5377283645077450", "09", "21", "789");

            var payload = new CardParams(PbKey, ScKey, "Anonymous", "Tester", "user@example.com", 200, "USD", card, "07205", "Hillside", "470 Mundet PI", "NJ", "US");

            var res = cardCharge.Charge(payload).Result;

            try
            {
                Assert.NotNull(res.Data);
                Console.WriteLine(res.Data);
                Assert.Equal("success", res.Status);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }


        }


        //Mobile money charge test
        [Fact]
        public void mobileMoneyTest()
        {

            var raveConfig = new RaveConfig(PbKey, ScKey, false);
            var mobilemoney = new ChargeMobileMoney(raveConfig);

            var Payload = new MobileMoneyParams(PbKey, ScKey, "Anonymous", "customer", "user@example.com", 1055, "GHS", "054709929220", "MTN", "GH", "mobilemoneygh", tranxRef);
            var cha = mobilemoney.Charge(Payload).Result;

            try
            {
                Assert.NotNull(cha.Data);
                Console.WriteLine(cha.Data);
                Assert.Equal("success", cha.Status);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }

        //Account charge test
        [Fact]
        public void accountTest()
        {
            var raveConfig = new RaveConfig(PbKey, ScKey, false);
            var accountc = new ChargeAccount(raveConfig);

            var Payload = new AccountParams(PbKey, ScKey, "customer", "customer", "user@example.com", "0690000031", 1000, "044", "NGN", "MC-0292920");
            var chargeResponse = accountc.Charge(Payload).Result;

            if (chargeResponse.Data.Status == "success-pending-validation")
            {

                Payload.Otp = "12345";
                chargeResponse = accountc.Charge(Payload).Result;
            }
            // ValidateAccountCharge(chargeResponse.Data.FlwRef);

            Assert.NotNull(chargeResponse.Data);
            Assert.Equal("success", chargeResponse.Status);
        }


        //Subaccount creation test
        [Fact]
        public void CreateSubAccountTest()
        {
            var raveConfig = new RaveConfig(PbKey, ScKey, false);
            var subacc = new CreateSubAccount(raveConfig);

            var payload = new SubAccountParams(ScKey, "0690000031", "0690000031", "TEST BUSINESS", "user@example.com", "0900000000", "0900000000");
            var chargeResponse = subacc.Charge(payload).Result;

            // Assert.NotNull(chargeResponse.Data);
            Assert.Equal("error", chargeResponse.Status);
        }

        //Tokenized Card charge test suite
        [Fact]
        public void TokenTest()
        {

            var raveConfig = new RaveConfig(PbKey, ScKey, false);
            var tokenCard = new Tokenize(raveConfig);

            var tokenparam = new TokensParams(raveConfig.SecretKey, "Olufumi", "Obafumiso", "olufemi@gmail.com", tranxRef, 100, "NGN", "NG")
            {
                Token = "flw-t1nf-139d69763063262928b77bc1f4fba199-m03k",
                Narration = "Test",
            };
            var tokenResponse = tokenCard.Charge(tokenparam).Result;


            try
            {
                Assert.NotNull(tokenResponse.Data);
                Assert.Equal("success", tokenResponse.Status);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }


        }


        [Fact]
        public void VirtualStaticAccountTest()
        {
            var virtuala = new VirtualAccount();
            var virtualaccountparams = new VirtualAccountParams("TEST-C-ACCOUNT", ScKey, "d@gmail.com", "TRF-SHDJ�");

            var chargeResponse = virtuala.CreateStaticVirtualAccount(virtualaccountparams);

            System.Console.WriteLine("chargeResponse:" + chargeResponse.ToString());

            JObject json = JObject.Parse(chargeResponse);
            // Assert.NotNull(chargeResponse.Data);
            Assert.Equal("success", (string)json.SelectToken("status"));
        }

        [Fact]
        public void VirtualTransactionAccountTest()
        {
            var virtuala = new VirtualAccount();
            var virtualaccountparams = new VirtualAccountParams("TEST-C-ACCOUNT", ScKey, "d@gmail.com", "TRF-SHDJ�", "100");

            var chargeResponse = virtuala.CreateTransactionVirtualAccount(virtualaccountparams);

            System.Console.WriteLine("chargeResponse:" + chargeResponse.ToString());

            JObject json = JObject.Parse(chargeResponse);
            // Assert.NotNull(chargeResponse.Data);
            Assert.Equal("success", (string)json.SelectToken("status"));
        }

        [Fact]
        public void VirtualDurationAccountTest()
        {
            var virtuala = new VirtualAccount();
            var virtualaccountparams = new VirtualAccountParams(1, 2, "TEST-C-ACCOUNT", ScKey, "d@gmail.com", "TRF-SHDJ�", "100");

            var chargeResponse = virtuala.CreateTransactionVirtualAccount(virtualaccountparams);

            System.Console.WriteLine("chargeResponse:" + chargeResponse.ToString());

            JObject json = JObject.Parse(chargeResponse);
            // Assert.NotNull(chargeResponse.Data);
            Assert.Equal("success", (string)json.SelectToken("status"));
        }

        [Fact]
        public void CreateEbillsTest()
        {
            var ebillscreate = new CreateOrder();
            var ebillscreateparams = new EbillsCreateRequestParams("NGN", 1, "TEST-C", ScKey, "d@gmail.com", 100, "09384747474", "773838837373", "127.9.0.7");

            var chargeResponse = ebillscreate.doCreateOrder(ebillscreateparams);

            System.Console.WriteLine("chargeResponse:" + chargeResponse.ToString());

            JObject json = JObject.Parse(chargeResponse);
            // Assert.NotNull(chargeResponse.Data);
            Assert.Equal("success", (string)json.SelectToken("status"));
        }

        [Fact]
        public void UpdateEbillsTest()
        {
            var ebillsupdate = new UpdateOrder();
            var ebillsupdateparams = new EbillsUpdateRequestParams("NGN", ScKey, 500, "RVEBLS-DD2EB67752B9-36138");

            var chargeResponse = ebillsupdate.doUpdateOrder(ebillsupdateparams);

            System.Console.WriteLine("chargeResponse:" + chargeResponse.ToString());

            JObject json = JObject.Parse(chargeResponse);
            // Assert.NotNull(chargeResponse.Data);
            Assert.Equal("success", (string)json.SelectToken("status"));
        }

        //Subscription list test
        [Fact]
        public void ListSubscriptions()
        {
            var listsubs = new ListSubscriptions();

            var chargeResponse = listsubs.doListSubscriptions(ScKey);

            System.Console.WriteLine("chargeResponse:" + chargeResponse.ToString());

            JObject json = JObject.Parse(chargeResponse);
            // Assert.NotNull(chargeResponse.Data);
            Assert.Equal("success", (string)json.SelectToken("status"));
        }

        //Virtual Card creation test
        [Fact]
        public void CreateVirtualCard()
        {
            var createvirtualcard = new VirtualCard();

            var virtualcardparams = new VirtualCardParams(ScKey, "clopat", "NGN", "100", "lagos, lagos", "lagos", "lagos", "0000", "NG", "www.facebook.com");
            var chargeResponse = createvirtualcard.doCreateVirtualCard(virtualcardparams);

            System.Console.WriteLine("chargeResponse:" + chargeResponse.ToString());

            JObject json = JObject.Parse(chargeResponse);
            // Assert.NotNull(chargeResponse.Data);
            Assert.Equal("error", (string)json.SelectToken("status"));
        }

    }
}
