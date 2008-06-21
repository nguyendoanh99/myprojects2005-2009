
#ifndef BT01_DESCRIPTORS_PAN_H
#define BT01_DESCRIPTORS_PAN_H

/** BT01_Descriptors application panic codes */
enum TBT01_DescriptorsPanics
	{
	EBT01_DescriptorsUi = 1
	// add further panics here
	};

inline void Panic(TBT01_DescriptorsPanics aReason)
	{
	_LIT(applicationName,"BT01_Descriptors");
	User::Panic(applicationName, aReason);
	}

#endif // BT01_DESCRIPTORS_PAN_H
