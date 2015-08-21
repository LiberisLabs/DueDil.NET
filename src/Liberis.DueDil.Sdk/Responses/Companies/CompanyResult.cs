using System;
using Newtonsoft.Json;

namespace Liberis.DueDil.Sdk.Responses.Companies
{
    public class CompanyResult
    {
        [JsonProperty(PropertyName = "id")]
        public string Id { get; set; }

        [JsonProperty(PropertyName = "last_update")]
        public DateTime LastUpdate { get; set; }

        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }

        [JsonProperty(PropertyName = "description")]
        public string Description { get; set; }

        [JsonProperty(PropertyName = "status")]
        public string Status { get; set; }

        [JsonProperty(PropertyName = "incorporation_date")]
        public DateTime IncorporationDate { get; set; }

        [JsonProperty(PropertyName = "latest_annual_return_date")]
        public DateTime LatestAnnualReturnDate { get; set; }

        [JsonProperty(PropertyName = "latest_accounts_date")]
        public DateTime LatestAccountsDate { get; set; }

        [JsonProperty(PropertyName = "company_type")]
        public string CompanyType { get; set; }

        [JsonProperty(PropertyName = "accounts_type")]
        public string AccountsType { get; set; }

        [JsonProperty(PropertyName = "sic_code")]
        public int SicCode { get; set; }

        [JsonProperty(PropertyName = "sic_description")]
        public string SicDescription { get; set; }
        
        [JsonProperty(PropertyName = "shareholdings_url")]
        public string ShareholdingsUrl { get; set; }
        
        [JsonProperty(PropertyName = "accounts_url")]
        public string AccountsUrl { get; set; }
        
        [JsonProperty(PropertyName = "directors_url")]
        public string DirectorsUrl { get; set; }

        [JsonProperty(PropertyName = "directorships_url")]
        public string DirectorshipsUrl { get; set; }

        [JsonProperty(PropertyName = "subsidiaries_url")]
        public string SubsidiariesUrl { get; set; }

        [JsonProperty(PropertyName = "documents_url")]
        public string DocumentsUrl { get; set; }

        [JsonProperty(PropertyName = "mortgages_url")]
        public string MortgagesUrl { get; set; }

        [JsonProperty(PropertyName = "reg_address_postcode")]
        public string RegisteredAddressPostcode { get; set; }

        [JsonProperty(PropertyName = "reg_area_code")]
        public string RegisteredAreaCode { get; set; }

        [JsonProperty(PropertyName = "reg_phone")]
        public string RegisteredPhone { get; set; }

        [JsonProperty(PropertyName = "reg_tps")]
        public string RegisteredTps { get; set; }

        [JsonProperty(PropertyName = "reg_web")]
        public string RegisteredWeb { get; set; }

        [JsonProperty(PropertyName = "sic2007code")]
        public int Sic2007Code { get; set; }

        [JsonProperty(PropertyName = "trading_address1")]
        public string TradingAddress1 { get; set; }

        [JsonProperty(PropertyName = "trading_address2")]
        public string TradingAddress2 { get; set; }

        [JsonProperty(PropertyName = "trading_address3")]
        public string TradingAddress3 { get; set; }

        [JsonProperty(PropertyName = "trading_address4")]
        public string TradingAddress4 { get; set; }

        [JsonProperty(PropertyName = "trading_address_postcode")]
        public string TradingAddressPostcode { get; set; }
    }
}