
#ifndef HELLOCARBIDE3RDGUI_PAN_H
#define HELLOCARBIDE3RDGUI_PAN_H

/** HelloCarbide3rdGUI application panic codes */
enum THelloCarbide3rdGUIPanics
	{
	EHelloCarbide3rdGUIUi = 1
	// add further panics here
	};

inline void Panic(THelloCarbide3rdGUIPanics aReason)
	{
	_LIT(applicationName,"HelloCarbide3rdGUI");
	User::Panic(applicationName, aReason);
	}

#endif // HELLOCARBIDE3RDGUI_PAN_H
