﻿using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace Dax.ViewVpaExport
{
    public class CalculationItem
        {
        [JsonIgnore]
        private readonly Dax.Model.CalculationItem _CalculationItem;
        internal CalculationItem(Dax.Model.CalculationItem calculationItem)
        {
            this._CalculationItem = calculationItem;
        }

        public string CalculationGroup { get { return this._CalculationItem.CalculationGroup.Table.TableName.Name; } }
        public string Attribute { get { return this._CalculationItem.CalculationGroup.Table.Columns.Find(c => c.IsCalculationGroupAttribute == true)?.ColumnName.Name; } }
        public bool IsHidden {
            get {
                var column = this._CalculationItem.CalculationGroup.Table.Columns.Find(c => c.IsCalculationGroupAttribute == true);
                return (column != null) ? column.IsHidden : false;
            }
        }
        public int Precedence { get { return this._CalculationItem.CalculationGroup.Precedence; } }
        public string ItemName { get { return this._CalculationItem.ItemName.Name; } }
        public string ItemExpression { get { return this._CalculationItem.ItemExpression?.Expression; } }
        public string State { get { return this._CalculationItem.State; } }
        public string ErrorMessage { get { return this._CalculationItem.ErrorMessage; } }
        public string FormatStringDefinition { get { return this._CalculationItem.FormatStringDefinition?.Expression; } }
        public string FormatStringState { get { return this._CalculationItem.FormatStringState; } }
        public string FormatStringErrorMessage { get { return this._CalculationItem.FormatStringErrorMessage; } }
    }
}