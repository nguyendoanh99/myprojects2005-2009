#include "stdafx.h"

using namespace System;
using namespace System::Data;
using namespace System::Data::Sql;
using namespace System::Data::SqlTypes;
using namespace Microsoft::SqlServer::Server;

// In order to debug your User-Defined Types, add the following to your debug.sql file:
//
//	if object_id ('test_table') is not null
//		DROP TABLE test_table

//	CREATE TABLE test_table (col1 Type1)
//	go

//	INSERT INTO test_table VALUES (convert(Type1, 'Instantiation String 1'))
//	INSERT INTO test_table VALUES (convert(Type1, 'Instantiation String 2'))
//	INSERT INTO test_table VALUES (convert(Type1, 'Instantiation String 3'))

//	select col1.Method1() from test_table
//	select col1.var1 from test_table
//	select Type1::Method2()

[Serializable]
[Microsoft::SqlServer::Server::SqlUserDefinedType(Format::Native)]
public value struct Type1 : public SqlTypes::INullable
{
public:
	virtual String ^ToString() override
	{
		// TODO: Put your code here
		return "";
	}
	property bool IsNull 
	{
		virtual bool get()
		{
			// TODO: Put your code here
			return m_Null;
		}
	}
	property static Type1 Null
	{
		Type1 get()
		{
			Type1 ^h = gcnew Type1();
            h->m_Null = true;
			return *h;
		}
	}

	static Type1 Parse(SqlTypes::SqlString s)
	{
		if (s.IsNull)
			return Type1::Null;
		Type1 ^u = gcnew Type1();
		// TODO: Put your code here
		return *u;
	}

	// This is a place-holder method
	System::String ^Method1()
	{
		// TODO: Insert method code here
		return L"Hello";
	}

	// This is a place-holder static method
	static SqlTypes::SqlString Method2()
	{
		// TODO: Insert method code here
		SqlTypes::SqlString Value(L"Hello");
		return Value;
	}

	// This is a place-holder field member
	int var1;

// Private member
private:
	bool m_Null;

};
