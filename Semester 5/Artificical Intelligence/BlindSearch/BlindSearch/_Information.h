#pragma once
#include <vector>
template<class STATE, class VALUE>
class _Information
{
public:	
	virtual VALUE GetCost(STATE X, STATE Y) = 0; // Chi phi di tu X den Y
	virtual std::vector<STATE> GetSucc(STATE X) = 0; // Tra ve cac trang thai sinh ra tu X
	virtual std::vector<STATE> GetStart() = 0; // Tra ve cac trang thai bat dau cua bai toan
	virtual std::vector<STATE> GetGoal() = 0; // Tra ve cac trang thai dich cua bai toan
	virtual VALUE GetG(STATE X) = 0; // Tra ve chi phi di tu trang thai bat dau den trang thai X (goi la chi phi g)
	virtual void SetG(STATE X, VALUE m) = 0; // Thay doi chi phi g bang m
	virtual VALUE GetH(STATE X) = 0; // Tra ve gia tri cua ham heuristic tai trang thai X
	virtual STATE GetPrevious(STATE X) = 0; // Lay trang thai cha cua X
	virtual void SetPrevious(STATE X, STATE Y) = 0; // Gan trang thai cha cua X la Y	
};
