
#ifndef TEMP_PAN_H
#define TEMP_PAN_H

/** temp application panic codes */
enum TtempPanics
	{
	EtempUi = 1
	// add further panics here
	};

inline void Panic(TtempPanics aReason)
	{
	_LIT(applicationName,"temp");
	User::Panic(applicationName, aReason);
	}

#endif // TEMP_PAN_H
