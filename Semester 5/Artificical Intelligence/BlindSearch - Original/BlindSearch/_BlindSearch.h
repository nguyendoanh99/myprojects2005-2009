#pragma once
#include "_Information.h"

template<class STATE, class VALUE>
class _BlindSearch
{
protected:
	_Information<STATE, VALUE> *m_Info;
public:
	_BlindSearch(_Information<STATE, VALUE> *data)
	{
		m_Info = data;
	}
	virtual bool Run() = 0;	
	virtual ~_BlindSearch(void)
	{
		m_Info = NULL;
	}
};
