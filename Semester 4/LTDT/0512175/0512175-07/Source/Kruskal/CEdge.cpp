#include "CEdge.h"

CEdge::CEdge(int v1, int v2, int w)
{
	this->v1 = v1;
	this->v2 = v2;
	this->w = w;
}

int CEdge::operator<(const CEdge& p)
{
	return (this->w < p.w);
}

int CEdge::operator ==(const CEdge &p)
{
	return (this->w == p.w);
}

int CEdge::operator >(const CEdge &p)
{
	return (this->w > p.w);
}

int CEdge::LayV1()
{
	return v1;
}

int CEdge::LayV2()
{
	return v2;
}

int CEdge::LayW()
{
	return w;
}