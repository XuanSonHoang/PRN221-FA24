﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Demo_Xml_Json
{

    // NOTE: Generated code may require at least .NET Framework 4.5 or .NET Core/Standard 2.0.
    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.w3.org/2001/XMLSchema")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.w3.org/2001/XMLSchema", IsNullable = false)]
    public partial class Catalog
    {

        private catalogBook[] bookField;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("book")]
        [JsonPropertyName("book")]
        public catalogBook[] book
        {
            get
            {
                return this.bookField;
            }
            set
            {
                this.bookField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class catalogBook
    {

        private string authorField;

        private string titleField;

        private string genreField;

        private decimal priceField;

        private System.DateTime publish_dateField;

        private string descriptionField;

        private string idField;

        /// <remarks/>
        /// 
        [JsonPropertyName("author")]
        public string author
        {
            get
            {
                return this.authorField;
            }
            set
            {
                this.authorField = value;
            }
        }

        /// <remarks/>
        [JsonPropertyName("title")]
        public string title
        {
            get
            {
                return this.titleField;
            }
            set
            {
                this.titleField = value;
            }
        }

        /// <remarks/>
        [JsonPropertyName("genre")]
        public string genre
        {
            get
            {
                return this.genreField;
            }
            set
            {
                this.genreField = value;
            }
        }

        /// <remarks/>
        [JsonPropertyName("price")]
        public decimal price
        {
            get
            {
                return this.priceField;
            }
            set
            {
                this.priceField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(DataType = "date")]
        [JsonPropertyName("publish_date")]
        public System.DateTime publish_date
        {
            get
            {
                return this.publish_dateField;
            }
            set
            {
                this.publish_dateField = value;
            }
        }

        /// <remarks/>
        [JsonPropertyName("description")]
        public string description
        {
            get
            {
                return this.descriptionField;
            }
            set
            {
                this.descriptionField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        [JsonPropertyName("_id")]
        public string id
        {
            get
            {
                return this.idField;
            }
            set
            {
                this.idField = value;
            }
        }
    }

    public class CatalogWrapper
    {
        [JsonPropertyName("catalog")]
        public Catalog Catalog { get; set; }
    }
}
