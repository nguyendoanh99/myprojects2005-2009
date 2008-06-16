using System;
using System.Collections.Generic;
using System.Text;
using System.Data.OleDb;

namespace DAO
{
    public class ConvertTypes
    {
        //**********************************************************
        // Attributes
        //**********************************************************
        private List<OleDbType> _OleDbTypes;
        private List<Type> _CSharpTypes;
        //**********************************************************
        // Private Functions
        //**********************************************************
       
        //**********************************************************
        // Contructors
        //**********************************************************
        public ConvertTypes()
        {
            
            _OleDbTypes = new List<OleDbType>();
            _CSharpTypes = new List<Type>();

            _OleDbTypes.Add(OleDbType.Integer);
            _CSharpTypes.Add(Type.GetType("System.Int32"));
            
            _OleDbTypes.Add(OleDbType.Boolean);
            _CSharpTypes.Add(Type.GetType("System.Boolean"));

            _OleDbTypes.Add(OleDbType.WChar);
            _CSharpTypes.Add(Type.GetType("System.String"));
            
            _OleDbTypes.Add(OleDbType.DBDate);
            _CSharpTypes.Add(Type.GetType("System.DateTime"));
            
            _OleDbTypes.Add(OleDbType.Currency);
            _CSharpTypes.Add(Type.GetType("System.Decimal"));

        }
        //	**********************************************************
        // Public Functions
        //**********************************************************
        public Type OleDbToCSharpType(OleDbType data_type)
        {
            Type result;
            int index = _OleDbTypes.IndexOf(data_type);
            result = _CSharpTypes[index];
            return result;
        }
        public OleDbType CSharpTypeToOleDb(Type data_type)
        {
            OleDbType result;
            int index = _CSharpTypes.IndexOf(data_type);
            result = _OleDbTypes[index];
            return result;
        }
    }
}
