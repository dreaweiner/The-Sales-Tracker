using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace The_Sales_Tracker
{
    class Product
    {
        public enum ProductType
        {
            None,
            Ozobots,
            Bloxels,
            Sphero
        }

        #region FIELDS

        private int _numberOfUnits;
        private bool _onBackOrder;
        private ProductType _type;
        private bool v;

        #endregion

        #region PROPERTIES

        public bool OnBackOrder
        {
            get { return _onBackOrder; }
            set { _onBackOrder = value; }
        }

        public int NumberOfUnits
        {
            get { return _numberOfUnits; }
        }

        public ProductType Type
        {
            get { return _type; }
            set { _type = value; }
        }

        public bool OnBackorder { get; internal set; }

        #endregion

        #region CONSTRUCTORS

        public Product()
        {
            _type = ProductType.None;
            _numberOfUnits = 0;
        }

        public Product(ProductType type, int numberOfUnits)
        {
            _type = type;
            _numberOfUnits = numberOfUnits;
        }

        public Product(ProductType type, int numberOfUnits, bool v) : this(type, numberOfUnits)
        {
            this.v = v;
        }

        #endregion

        #region METHODS
        ///
        /// Add Products Number of Units
        /// 
        public void AddProducts(int unitsToAdd)
        {
            _numberOfUnits += unitsToAdd;
        }

        ///
        /// Subtract to Add Number of Units
        /// 
        public void SubtractProducts(int unitsToSubtract)
        {
            if (_numberOfUnits < unitsToSubtract)
            {
                _onBackOrder = true;
            }
            _numberOfUnits -= unitsToSubtract;
        }

        #endregion
    }
}
