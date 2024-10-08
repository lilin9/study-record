﻿using Microsoft.EntityFrameworkCore;

namespace Domain.Models {
    /// <summary>
    /// Address 值对象
    /// </summary>
    [Owned]
    public class Address: ValueObject<Address> {
        /// <summary>
        /// 省份
        /// </summary>
        public string Province { get; private set; }
        /// <summary>
        /// 城市
        /// </summary>
        public string City { get; private set; }
        /// <summary>
        /// 区县
        /// </summary>
        public string County { get; private set; }
        /// <summary>
        /// 街道
        /// </summary>
        public string Street { get; private set; }


        public Address() { }

        public Address(string province, string city, string county, string street) {
            Province = province;
            City = city;
            County = county;
            Street = street;
        }

        protected override bool EqualsCore(Address other) {
            throw new NotImplementedException();
        }

        protected override int GetHashCodeCore() {
            throw new NotImplementedException();
        }
    }
}
