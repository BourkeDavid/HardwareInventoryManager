﻿using HardwareInventoryManager.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HardwareInventoryManager.ViewModels
{
    public class AssetViewModel : AppViewModel
    {

        public int AssetId { get; set; }

        public int TenantId { get; set; }

        //[JsonIgnore]
        public Tenant Tenant { get; set; }

        public int AssetMakeId { get; set; }

        public Lookup AssetMake { get; set; }

        [Required]
        public string Model { get; set; }

        [Display(Name = "Serial Number")]
        public string SerialNumber { get; set; }

        [Display(Name = "Purchase Date")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? PurchaseDate { get; set; }

        public string PurchaseDateFormatted
        {
            get 
            { 
                return PurchaseDate.HasValue ? PurchaseDate.Value.ToString("dd/MM/yyyy") : string.Empty ;
            }
        }

        public int WarrantyPeriodId { get; set; }

        [Display(Name = "Warranty Period")]
        public Lookup WarrantyPeriod { get; set; }

        [Display(Name = "Obsolescense Date")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? ObsolescenseDate { get; set; }

        public string ObsolescenceDateFormatted
        {
            get
            {
                return ObsolescenseDate.HasValue ? ObsolescenseDate.Value.ToString("dd/MM/yyyy") : string.Empty;
            }
        }

        [Display(Name = "Price Paid")]
        public Decimal? PricePaid { get; set; }

        public int CategoryId { get; set; }

        public Lookup Category { get; set; }

        [Display(Name = "Location or Room")]
        public string LocationDescription { get; set; }

        public SelectList TenantOrganisationSelectList { get; set; }

        public SelectList AssetMakeSelectList { get; set; }

        public SelectList CategorySelectList { get; set; }

        public SelectList WarrantyPeriodSelectList { get; set; }
        
        public AssetDetailViewModel NetworkedAssetDetail { get; set; }
    }
}