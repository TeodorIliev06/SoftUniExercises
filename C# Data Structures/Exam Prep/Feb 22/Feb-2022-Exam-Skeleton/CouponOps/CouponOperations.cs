using System.Linq;

namespace CouponOps
{
    using CouponOps.Models;
    using Interfaces;
    using System;
    using System.Collections.Generic;

    public class CouponOperations : ICouponOperations
    {
        private Dictionary<string, Coupon> couponsByCode = new Dictionary<string, Coupon>();
        private Dictionary<string, Website> websitesByDomain = new Dictionary<string, Website>();
        public void AddCoupon(Website website, Coupon coupon)
        {
            if (!this.websitesByDomain.ContainsKey(website.Domain))
            {
                throw new ArgumentException();
            }

            this.couponsByCode.Add(coupon.Code, coupon);
            this.websitesByDomain[website.Domain].Coupons.Add(coupon);
            coupon.Website = website;
        }

        public bool Exist(Website website) => this.websitesByDomain.ContainsKey(website.Domain);

        public bool Exist(Coupon coupon) => this.couponsByCode.ContainsKey(coupon.Code);

        public IEnumerable<Coupon> GetCouponsForWebsite(Website website)
        {
            if (!this.websitesByDomain.ContainsKey(website.Domain))
            {
                throw new ArgumentException();
            }

            return this.websitesByDomain[website.Domain].Coupons;
        }

        public IEnumerable<Coupon> GetCouponsOrderedByValidityDescAndDiscountPercentageDesc()
            => this.couponsByCode.Values
                .OrderByDescending(c => c.Validity)
                .ThenByDescending(c => c.DiscountPercentage);

        public IEnumerable<Website> GetSites() => this.websitesByDomain.Values;

        public IEnumerable<Website> GetWebsitesOrderedByUserCountAndCouponsCountDesc()
            => this.GetSites().OrderBy(w => w.UsersCount)
                .ThenByDescending(w => w.Coupons.Count);

        public void RegisterSite(Website website)
        {
            if (this.websitesByDomain.ContainsKey(website.Domain))
            {
                throw new ArgumentException();
            }

            this.websitesByDomain.Add(website.Domain, website);
        }

        public Coupon RemoveCoupon(string code)
        {
            if (!this.couponsByCode.ContainsKey(code))
            {
                throw new ArgumentException();
            }

            var coupon = this.couponsByCode[code];
            this.couponsByCode.Remove(code);
            coupon.Website.Coupons.Remove(coupon);

            return coupon;
        }

        public Website RemoveWebsite(string domain)
        {
            if (!this.websitesByDomain.ContainsKey(domain))
            {
                throw new ArgumentException();
            }

            var website = this.websitesByDomain[domain];
            this.websitesByDomain.Remove(domain);
            website.Coupons.ForEach(c => this.couponsByCode.Remove(c.Code));

            return website;
        }

        public void UseCoupon(Website website, Coupon coupon)
        {
            if (!this.websitesByDomain.ContainsKey(website.Domain) ||
                !this.couponsByCode.ContainsKey(coupon.Code) ||
                !this.websitesByDomain[website.Domain].Coupons.Contains(coupon))
            {
                throw new ArgumentException();
            }

            this.couponsByCode.Remove(coupon.Code);
            this.websitesByDomain[website.Domain].Coupons.Remove(coupon);
        }
    }
}
