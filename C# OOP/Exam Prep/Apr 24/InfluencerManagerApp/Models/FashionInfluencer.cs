﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfluencerManagerApp.Models
{
    public class FashionInfluencer : Influencer
    {
        private const double EngagementRate = 4.0d;
        private const double Factor = 0.1d;
        public FashionInfluencer(string username, int followers)
            : base(username, followers, EngagementRate)
        {
        }

        public override int CalculateCampaignPrice()
        {
            return (int)Math.Floor(Followers * base.EngagementRate * Factor);
        }
    }
}
