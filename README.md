# Rave.NET

.NET Standard API for interfacing with Rave (Flutterwave's payment gateway)

The following was copied as is from the offical project found [here](https://github.com/Flutterwave/Flutterwave-dotnet) with modifications.

![.NET Core](https://github.com/DaraOladapo/Rave.NET/workflows/.NET%20Core/badge.svg)

## Introduction

The Rave .NET Library implements the following payment services:

1. Card Payments
2. Bank Account Payments.
3. Mobile Money Payments.
4. Bank Transfer (NGN).
5. Subscriptions.
6. Virtual Cards.

The Library also implements the following features:

1. Tokeniztion
2. Subaccounts
3. Currencies.
4. Pre-Authorisation.
5. Refunds.

## Prerequisites

- .NET Standard 2.0+

## Installation

Using .NET CLI

`dotnet add package Rave.NET --version 1.0.2`

Using Package Manager Console

`Install-Package Rave.NET -Version 1.0.2`

Using Package Reference
 
`<PackageReference Include="Rave.NET" Version="1.0.2" />`

Using Paket CLI

`paket add Rave.NET --version 1.0.2`

## Usage

- Import Namespaces

``` C#
using Rave.NET.API;
using Rave.NET.Models.Card;
using Rave.NET.Models.Charge;
```

- Set up Rave Configuration

    Rave Config takes in 3 arguments
  - PbKey: Public key
  - ScKey: Secret Key
  - false/true: false if test key, true if live keys

```C#
private static RaveConfig raveConfig = new RaveConfig(PbKey, ScKey, false);
```

- Create Card
 Create a card taking in your user's input

```C#
private static Card card = new Card(CardNumber, ExpiryMonth, ExpiryYear, CVV);
```

- Create payload and card charge for Rave API

```C#
  private static CardParams payload = new CardParams(PbKey, ScKey, "Anonymous", "Tester", "user@example.com", 50000, "NGN", card) { TxRef = tranxRef };
  private static ChargeCard cardCharge = new ChargeCard(raveConfig);
```

- Charge Card

```C#
RaveResponse<ResponseData> chargeResult = new API.RaveResponse<ResponseData>();
chargeResult = await cardCharge.Charge(payload);
```

- The following logic will be based on the result of the charge. The code sample below was written for Xamarin.Forms

```C#
if (chargeResult.Message == "AUTH_SUGGESTION" && chargeResult.Data.SuggestedAuth == "PIN")
{
    PINEntryPanel.IsVisible = true;
}
else
{
    await DisplayAlert(chargeResult.Status, chargeResult.Message, "OK");

}
```

Next step if the charge requires a PIN

```C#
payload.Pin = "3310";
payload.SuggestedAuth = "PIN";
 if (chargeResult.Message == "AUTH_SUGGESTION" && chargeResult.Data.SuggestedAuth == "OTP")
    {
        OTPEntryPanel.IsVisible = true;
    }
    else
    {
        await DisplayAlert(chargeResult.Status, chargeResult.Message, "OK");
    }
```

If an OTP is required

```C#
payload.SuggestedAuth = "OTP";
payload.Otp = "12345";
chargeResult = await cardCharge.Charge(payload);
await DisplayAlert(chargeResult.Status, chargeResult.Message, "OK");
```

Happy Usage. 😍

<!-- ## Configuration

Add all relevant modules

```bash
    using System.Diagnostics;
    using System.Collections.Generic;
    using Rave.NET.Models.MobileMoney;
    using Rave.NET.Models.VirtualCard;
    using Rave.NET.Models.Subaccount;
    using Rave.NET.Models.Tokens;
    using Rave.NET.Models;
    using Rave.NET.Models.Charge;
    using Rave.NET.Models.Account;
    using Rave.NET.Models.Card;
    using Rave.NET.Models.Validation;
    using NUnit.Framework;
```

Pass Public and Secret keys as variables for configuration.

```bash
    private static string PbKey = "pass your public key here"
    private static string ScKey = "pass your secret key here"
    var raveConfig = new RaveConfig(PbKey, SCKey, false);
```


# Payments

## Card Payments

This implements Card payments for Pin, 3D-Secure, VBV and PreAuth transactions.

## Usage

1. Complete basic configuration following the configuration steps.

2. Configure the card charge

```bash
    var cardCharge = new ChargeCard(raveConfig);
```

3. Pass Card parameters as payload.
The payload should contain: 
    - `Public key` 
    - `First name`
    - `Last name` 
    - `Email address` 
    - `Amount`
    - `Card details.` 

These card details include:

- `Card number`
- `CVV`
- `Expiry month`
- `Expiry year`
- `Trans Ref`

```bash
var Payload = new CardParams(PbKey, "Anonymous", "Customer", "tester@example.com", 2100){ cardNo = "5438898014560229", Cvv = "789", Expirymonth = "09", Expiryyear = "19", TxRef = tranxRef}
```

4. Charge card.

```bash
var cha = cardCharge.Charge(Payload).Result;
```

5. Pass Pin and OTP to complete the Transaction

```bash
 if (cha.Message == "AUTH_SUGGESTION" && cha.Data.SuggestedAuth == "PIN")
            {
                cardParams.Pin = "3310";
                cardParams.Otp = "12345";
                cardParams.SuggestedAuth = "PIN";
                cha = cardCharge.Charge(Payload).Result;
            }
```

**The complete card charge and validation flow:**
```bash
    class Program
    {
        private static string tranxRef = "454839";
        private static string PbKey = "";
        private static string ScKey = "";
        static void Main(string[] args)
        { 
            var raveConfig = new RaveConfig(PbKey, ScKey, false);
            var cardCharge = new CardCharge(raveConfig);

            var Payload = new CardChargeParams(PbKey, "Anonymous", "Customer", "tester@example.com", 2100)
            { CardNo = "5438898014560229", Cvv = "789", Expirymonth = "09", Expiryyear = "19", TxRef = tranxRef }
            ;
            var cha = cardCharge.Charge(cardParams).Result;


            if (cha.Message == "AUTH_SUGGESTION" && cha.Data.SuggestedAuth == "PIN")
            {
                cardParams.Pin = "3310";
                cardParams.Otp = "12345";
                cardParams.SuggestedAuth = "PIN";
                cha = cardCharge.Charge(Payload).Result;
            }


        }
    }
```

## Account Payments

This implements direct debit transactions from Bank accounts.

### Usage

1. Complete basic configuration following the configuration steps.

2. Configure the Account charge
```bash
    var accountCharge = new ChargeAccount(raveConfig);
```

3. Pass Account parameters as payload. The payload should contain: 

- `Public key` 
- `First name`
- `Last name` 
- `Email address`
- `Account number`
- `Amount`
- `Bank code.`
- `Currency (NGN)`
- `Trans Ref`

```bash
    var Payload = new AccountParams(PbKey, "Anonymous", "customer", "user@example.com", "0690000031", 1000.00m, "044", "NGN", "MC-0292920");
```

4. Charge Account.

```bash
    var chargeResponse = await accountCharge.Charge(accountParams);

    if (chargeResponse.Data.Status == "success-pending-validation")
    {
        // This usually means the user needs to validate the transaction with an OTP
        accountParams.Otp = "12345";
        chargeResponse = accountCharge.Charge(accountParams).Result;
    }

    Trace.WriteLine(chargeResponse.Data.ValidateInstructions.Instruction);
    Trace.WriteLine(chargeResponse.Data.ValidateInstructions.Valparams);
    Trace.WriteLine(chargeResponse.Data.ValidateInstruction);          
```

**The complete card charge and validation flow:**
```bash
    class Program
        {
            private static string tranxRef = "454839";
            private static string PbKey = "";
            private static string ScKey = "";
            static void Main(string[] args)
            {
                
                var raveConfig = new RaveConfig(recurringPbKey, recurringScKey, false);
                var accountCharge = new ChargeAccount(raveConfig);

                var Payload = new AccountParams(PbKey, "Anonymous", "customer", "user@example.com", "0690000031", 1000.00m, "044", "MC-0292920");
                var chargeResponse = await accountCharge.Charge(accountParams);


                if (chargeResponse.Data.Status == "success-pending-validation")
                {
                    // This usually means the user needs to validate the transaction with an OTP
                    accountParams.Otp = "12345";
                    chargeResponse = accountCharge.Charge(accountParams).Result;
                }


                Trace.WriteLine(chargeResponse.Data.ValidateInstructions.Instruction);
                Trace.WriteLine(chargeResponse.Data.ValidateInstructions.Valparams);
                Trace.WriteLine(chargeResponse.Data.ValidateInstruction);
                ValidateAccountCharge(chargeResponse.Data.FlwRef);


            }
        }
```

## Mobile Money Payments

This implements Mpesa, Ghana, Uganda, Zambia and Rwanda Mobile money transactions for customers.

## Usage

1. Complete basic configuration following the configuration steps.

2. Configure the Mobile money charge

```bash
var mobilemoney = new ChargeMobileMoney(raveConfig);
```

3. Pass mobile money parameters as payload. The payload should contain: 

- `Public key`
- `Secret key`
- `First name`
- `Last name` 
- `Email address`
- `Amount`
- `Currency`
- `Mobile number`
- `Network`
- `Country`
- `Payment Type`
- `Trans Ref`

```bash
    var Payload = new MobileMoneyParams(PbKey, ScKey, "Anonymous", "customer", "user@example.com",  1055, "GHS", "054709929220", "network", "country", "paymentType", "MC-0292920");
```

The payload parameters differ for different countries, currencies and payment types.

| Country | Payment Type | Country code | Currency | Network |
| ------- | ------------ | ------------ | -------- | ------- |
| Ghana | `mobilemoneygh` | `GH` | GHS | `MTN, VODAFONE, TIGO` |
| Kenya | `mpesa` | `KE` | KES |    
| Rwanda | `mobilemoneygh` | `NG` | RWF | `RWF` |
| Zambia |  `mobilemoneyzambia` | `NG` | ZMW | `MTN` |
| Uganda | `mobilemoneyuganda` | `UG` | UGX | `UGX` |

4. Carry out mobile money charge

```bash
    var cha = mobilemoney.Charge(Payload).Result;
```

**The Complete flow for mobile money charge:**
```bash
class Program
    {
        private static string tranxRef = "454839";
        private static string PbKey = "";
        private static string ScKey = "";
        static void Main(string[] args)
        {
            var raveConfig = new RaveConfig(recurringPbKey, recurringScKey, false);
            var mobilemoney = new ChargeMobileMoney(raveConfig);

            var Payload = new MobileMoneyParams(PbKey, ScKey, "Anonymous", "customer", "user@example.com",  1055, "GHS", "054709929220", "MTN", "GH", "mobilemoneygh", tranxRef);
            var cha = mobilemoney.Charge(Payload).Result;
        }
```

## Bank Transfers
This shows how to create an account number for customers to pay you with using the pay with bank transfer feature.

## Usage

**Static Accounts:**
```
   var virtualacct = new VirtualAccount();
   var virtualaccountparams = new VirtualAccountParams(narration, ScKey, email, reference);
   var chargeResponse = virtuala.CreateStaticVirtualAccount(virtualaccountparams);

```

**Transaction Accounts:**
```
    var virtuala = new VirtualAccount();
    var virtualaccountparams = new VirtualAccountParams(narration, ScKey, email, reference, amount);
    var chargeResponse = virtuala.CreateTransactionVirtualAccount(virtualaccountparams);

```

**Duration Accounts:**
```
    var virtuala = new VirtualAccount();
    var virtualaccountparams = new VirtualAccountParams(frequency, durtion, narration, ScKey, email, ref, amount);
    var chargeResponse = virtuala.CreateTransactionVirtualAccount(virtualaccountparams);

```

## Ebills
This API allows you to create and update a new Ebills order.

## Usage

**Create Ebills:**
```
    var ebillscreate = new CreateOrder();
    var ebillscreateparams = new EbillsCreateRequestParams(currency, numberofunits, narraction, ScKey, email, amount, phonenumber, txRef, IP);
    var chargeResponse = ebillscreate.doCreateOrder(ebillscreateparams);

```

**Update Ebills:**
```
      var ebillsupdate = new UpdateOrder();
      var ebillsupdateparams = new EbillsUpdateRequestParams(currency, ScKey, amount, flwref");
      var chargeResponse = ebillsupdate.doUpdateOrder(ebillsupdateparams);

```

## Tokenization
This implements Card tokenization for Pin, 3D-Secure, VBV and NoAuth cards.

## Usage
1. Complete basic configuration following the configuration steps.

2. Charge the card using instructions from the Card charge section of the documentation.

3. Configure the tokenized card
```
var tokenCard = new Tokenize(raveConfig);
```

4. Pass tokenized card parameters as payload.
The payload should contain: 
- `Secret key` 
- `First name`
- `Last name` 
- `Email address`
- `Transaction ref`
- `Amount`
- `currency`
- `embed token`
- `Narration`

```
var Payload = new TokensParams(ScKey, "Anonymous", "Customer", "tester@example.com", tranxref, 2100, "NGN", "NG"){ Token = "flw-t1nf-139d69763063262928b77bc1f4fba199-m03k", Narration = "Test"};
```

5. Make tokenized charge.
```
var tokenResponse = tokenCard.Charge(tokenparam).Result;
```

**The complete tokenized card charge:**
```
    class Program
    {
        private static string tranxRef = "454839";
        private static string PbKey = "";
        private static string ScKey = "";
        static void Main(string[] args)
        {
            
            var raveConfig = new RaveConfig(PbKey, ScKey, false);
            var cardCharge = new CardCharge(raveConfig);

            var Payload = new TokensParams(ScKey, "Anonymous", "Customer", "tester@example.com", tranxref, 2100, "NGN", "NG"){ Token = "flw-t1nf-139d69763063262928b77bc1f4fba199-m03k", Narration = "Test"};
            
            var tokenResponse = tokenCard.Charge(tokenparam).Result;

        }
    }
    
```

## SubAccounts
This implements subaccount creation for split payments.

## Usage
1. Complete basic configuration following the configuration steps.

2. Configure the SubAccount
```
var subacc = new CreateSubAccount(raveConfig);
```

3. Pass tokenized card parameters as payload.
The payload should contain: 
- `Secret key` 
- `Account Bank`
- `Account number`
- `Business Name`
- `Business Email`
- `Business contact `
- `Business contact  mobile`

```
var payload = new SubAccountParams(ScKey, "0690000031", "0690000031", "TEST BUSINESS", "user@example.com", "0900000000", "0900000000");
```

please note that the same value can be passed as business contact and business contact number.

4. Create the Subaccount.
```
var chargeResponse = subacc.Charge(payload).Result;
```

**The complete subaccount creation flow:**
```
    class Program
    {
        private static string tranxRef = "454839";
        private static string PbKey = "";
        private static string ScKey = "";
        static void Main(string[] args)
        {
            
            var raveConfig = new RaveConfig(PbKey, ScKey, false);
            var subacc = new CreateSubAccount(raveConfig);

            var payload = new SubAccountParams(ScKey, "0690000031", "0690000031", "TEST BUSINESS", "user@example.com", "0900000000", "0900000000");
            
            var chargeResponse = subacc.Charge(payload).Result;

        }
    }
     -->