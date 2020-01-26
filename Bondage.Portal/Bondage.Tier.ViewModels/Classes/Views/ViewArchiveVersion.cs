﻿using System;
using System.Xml.Serialization;

using Bondage.Tier.ViewModels.Interfaces.Views;

namespace Bondage.Tier.ViewModels.Classes.Views
{
    [XmlRoot("archive-version")]
    public class ViewArchiveVersion : IViewKey, IViewBase
    {
        public ViewArchiveVersion()
        {
        }

        [XmlElement("id")]
        public int Id { get; set; }

        [XmlElement("last-modified")]
        public DateTime LastModified { get; set; }

        [XmlElement("archive")]
        public virtual ViewArchive Archive { get; set; }

        [XmlElement("name")]
        public string Name => Archive?.Name;
    }
}
