
#ifndef CONVERSION_PAN_H
#define CONVERSION_PAN_H

/** Conversion application panic codes */
enum TConversionPanics
	{
	EConversionUi = 1
	// add further panics here
	};

inline void Panic(TConversionPanics aReason)
	{
	_LIT(applicationName,"Conversion");
	User::Panic(applicationName, aReason);
	}

#endif // CONVERSION_PAN_H
