
#ifndef BAITAP1_PAN_H
#define BAITAP1_PAN_H

/** BaiTap1 application panic codes */
enum TBaiTap1Panics
	{
	EBaiTap1Ui = 1
	// add further panics here
	};

inline void Panic(TBaiTap1Panics aReason)
	{
	_LIT(applicationName,"BaiTap1");
	User::Panic(applicationName, aReason);
	}

#endif // BAITAP1_PAN_H
