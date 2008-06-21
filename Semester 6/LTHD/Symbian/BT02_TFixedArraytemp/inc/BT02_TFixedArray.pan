
#ifndef BT02_TFIXEDARRAY_PAN_H
#define BT02_TFIXEDARRAY_PAN_H

/** BT02_TFixedArray application panic codes */
enum TBT02_TFixedArrayPanics
	{
	EBT02_TFixedArrayUi = 1
	// add further panics here
	};

inline void Panic(TBT02_TFixedArrayPanics aReason)
	{
	_LIT(applicationName,"BT02_TFixedArray");
	User::Panic(applicationName, aReason);
	}

#endif // BT02_TFIXEDARRAY_PAN_H
