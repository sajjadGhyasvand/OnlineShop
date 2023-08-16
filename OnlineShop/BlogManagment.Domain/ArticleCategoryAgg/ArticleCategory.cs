﻿using _0_FrameWork.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogManagment.Domain.ArticleCategoryAgg
{
    public class ArticleCategory : EntityBase
    {
        public string Name { get; private set; }
        public string Picture { get; private set; }
        public string Description { get; private set; }
        public string ShowOrder { get; private set; }
        public string Slug { get; private set; }
        public string KeyWords { get; private set; }
        public string MetaDescription { get; private set; }
        public string CanonicalAddress { get; private set; }

        public ArticleCategory(string name, string picture, string description, string showOrder, string slug, string keyWords, string metaDescription, string canonicalAddress)
        {
            Name=name;
            Picture=picture;
            Description=description;
            ShowOrder=showOrder;
            Slug=slug;
            KeyWords=keyWords;
            MetaDescription=metaDescription;
            CanonicalAddress=canonicalAddress;
        }
        public void Edit(string name, string picture, string description, string showOrder,
            string slug, string keyWords, string metaDescription, string canonicalAddress)
        {
            Name=name;
            if (!string.IsNullOrWhiteSpace(picture))
            Picture=picture;
            Description=description;
            ShowOrder=showOrder;
            Slug=slug;
            KeyWords=keyWords;
            MetaDescription=metaDescription;
            CanonicalAddress=canonicalAddress;
        }
    }
}
