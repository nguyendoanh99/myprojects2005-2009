#ifndef SORTING_H
#define SORTING_H

int input(char *filename ,int *a ,int n,int &x,int &k);

void hoanvi(int &,int &);

// QUICK SORT
void quicksort_tang(int *a,int l,int r);
void quicksort_giam(int *a,int l,int r);

// MERGE SORT
void mergesort_tang(int *a,int n);
void mergesort_giam(int *a,int n);

// SHELL SORT
void shellsort_tang(int *a,int n,int h[],int k);
void shellsort_giam(int *a,int n,int h[],int k);

// HEAP SORT TANG
void shift_tang(int *a,int l,int r);
void createheap_tang(int *a,int n);
void heapsort_tang(int *a,int n);

// HEAP SORT GIAM
void shift_giam(int *a,int l,int r);
void createheap_giam(int *a,int n);
void heapsort_giam(int *a,int n);

void doimang(int *a,int n,int k);

int output(char *filename ,int *a , int n);


#endif