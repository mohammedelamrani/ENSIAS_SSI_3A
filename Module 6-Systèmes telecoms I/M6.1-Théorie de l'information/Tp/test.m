N=5;
SNR=[1:10];
for i=1:10
    SNR_LIN=10^(SNR(i)/10);
    sigma=sqrt(1/(2*SNR_LIN));
    B=rand(1,N)<0.5;
    X=2*B-1;
    Y=X+sigma*randn(1,N);
    D=Y>=0.0;
	         cpterr=xor(B,D)
    vecterr=B~=D
    numerr=sum(vecterr);
    TEBs(i)=numerr/N;
end
