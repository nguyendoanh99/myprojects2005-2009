/*
========================================================================
 Name        : BaiTap1ContainerView.h
 Author      : 
 Copyright   : Your copyright notice
 Description : 
========================================================================
*/
#ifndef BAITAP1CONTAINERVIEW_H
#define BAITAP1CONTAINERVIEW_H

// [[[ begin generated region: do not modify [Generated Includes]
#include <aknview.h>
// ]]] end generated region [Generated Includes]


// [[[ begin [Event Handler Includes]
// ]]] end [Event Handler Includes]

// [[[ begin generated region: do not modify [Generated Forward Declarations]
class CBaiTap1Container;
// ]]] end generated region [Generated Forward Declarations]

// [[[ begin generated region: do not modify [Generated Constants]
// ]]] end generated region [Generated Constants]

/**
 * Avkon view class for BaiTap1ContainerView. It is register with the view server
 * by the AppUi. It owns the container control.
 * @class	CBaiTap1ContainerView BaiTap1ContainerView.h
 */
class CBaiTap1ContainerView : public CAknView
	{
public:
	// constructors and destructor
	CBaiTap1ContainerView();
	static CBaiTap1ContainerView* NewL();
	static CBaiTap1ContainerView* NewLC();        
	void ConstructL();
	virtual ~CBaiTap1ContainerView();

public:
	// from base class CAknView
	TUid Id() const;
	void HandleCommandL( TInt aCommand );

protected:
	// from base class CAknView
	void DoActivateL(
		const TVwsViewId& aPrevViewId,
		TUid aCustomMessageId,
		const TDesC8& aCustomMessage );
	void DoDeactivate();
	void HandleStatusPaneSizeChange();
	
private:
	void SetupStatusPaneL();
	void CleanupStatusPane();
	// [[[ begin generated region: do not modify [Generated Methods]
public: 
	// ]]] end generated region [Generated Methods]
	
	
	// [[[ begin [Overridden Methods]
protected: 
	// ]]] end [Overridden Methods]
	
	
	// [[[ begin [User Handlers]
protected: 
	TBool HandleTinh_khoang_cachMenuItemSelectedL( TInt aCommand );
	TBool HandleChu_vi_dien_tich_HCNMenuItemSelectedL( TInt aCommand );
	TBool HandleChu_vi_dien_tich_duong_tronMenuItemSelectedL( TInt aCommand );
	TBool HandleTao_doi_tuong_tam_giacMenuItemSelectedL( TInt aCommand );
	TBool HandleTao_doi_tuong_duong_tronMenuItemSelectedL( TInt aCommand );
	// ]]] end [User Handlers]
	
	// [[[ begin generated region: do not modify [Generated Instance Variables]
private: 
	CBaiTap1Container* iBaiTap1Container;
	// ]]] end generated region [Generated Instance Variables]
	
	};

#endif // BAITAP1CONTAINERVIEW_H			
