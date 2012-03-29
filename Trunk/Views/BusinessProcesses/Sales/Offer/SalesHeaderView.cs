﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace Views.BusinessProcesses.Sales.Offer
{
    [Serializable]
    class SalesHeaderView : ISalesHeaderView, IDataErrorInfo
    {

        public SalesHeaderView()
        {
        }

        public SalesHeaderView(int offerId, int? offerNumber, int? offerCustomer, DateTime? offerCreateDate, int? salestype)
        {
            this.SalesHeaderId = offerId;
            this.SalesHeaderNumber = offerNumber;
            this.SalesHeaderCustomer = offerCustomer;
            this.SalesHeaderCreateDate = offerCreateDate;
            this.SalesHeaderType = salestype;
        }


        public int SalesHeaderId { get; set; }
        public int? SalesHeaderNumber { get; set; }
        public int? SalesHeaderCustomer { get; set; }
        public DateTime? SalesHeaderCreateDate { get; set; }
        public int? SalesHeaderType { get; set; }



        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("SalesHeaderId", SalesHeaderId);
            info.AddValue("SalesHeaderNumber", SalesHeaderNumber);
            info.AddValue("SalesHeaderCustomer", SalesHeaderCustomer);
            info.AddValue("SalesHeaderCreateDate", SalesHeaderCreateDate);
            info.AddValue("SalesHeaderType", SalesHeaderType);
        }

        protected SalesHeaderView(SerializationInfo info,StreamingContext context)
        {
            SalesHeaderId = (int)info.GetValue("SalesHeaderId", typeof(int));
            SalesHeaderNumber = (int?)info.GetValue("SalesHeaderNumber", typeof(int));
            SalesHeaderCustomer = (int?)info.GetValue("SalesHeaderCustomer", typeof(int?));
            SalesHeaderCreateDate = (DateTime?)info.GetValue("SalesHeaderCreateDate", typeof(DateTime?));
            SalesHeaderType = (int?)info.GetValue("SalesHeaderType", typeof(int?));
        }


        string IDataErrorInfo.Error { get { return null; } }

        string IDataErrorInfo.this[string propertyName]
        {
            get { return this.GetValidationError(propertyName); }
        }

        private string GetValidationError(string propertyName)
        {
            string error = null;

            switch (propertyName)
            {
                case "SalesHeaderNumber":
                    error = this.ValidateOfferNumber();
                    break;

                case "SalesHeaderCustomer":
                    error = this.ValidateOfferCustomer();
                    break;

                case "SalesHeaderCreateDate":
                    error = this.ValidateOfferCreateDate();
                    break;

                default:
                    Debug.Fail("Unexpected property being validated on Offer: " + propertyName);
                    break;
            }

            return error;
        }

        private string ValidateOfferNumber()
        {
            if (IsStringMissing(Convert.ToString(SalesHeaderNumber)))
                return "Missing Offer Number";

            return null;
        }

        private string ValidateOfferCustomer()
        {
            if (IsStringMissing(Convert.ToString(SalesHeaderCustomer)))
                return "Missing Offer Customer";

            return null;
        }

        private string ValidateOfferCreateDate()
        {
            if (IsStringMissing(Convert.ToString(SalesHeaderCreateDate)))
                return "Missing Offer create date";

            return null;
        }

        static bool IsStringMissing(string value)
        {
            return
                String.IsNullOrEmpty(value) ||
                value.Trim() == String.Empty;
        }

        static readonly string[] ValidatedProperties = 
        { 
            "SalesHeaderNumber", 
            "SalesHeaderCustomer", 
            "SalesHeaderCreateDate"
        };

        public bool IsValid
        {
            get
            { return ValidatedProperties.All(property => GetValidationError(property) == null); }
        }

    }



}
