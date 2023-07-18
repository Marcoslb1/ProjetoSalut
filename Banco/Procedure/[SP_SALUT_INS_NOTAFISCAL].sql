CREATE PROCEDURE [dbo].[SP_SALUT_INS_NOTAFISCAL]                      
@des_cnpj varchar(50) NULL,                      
@cod_canalcompra INT NULL,    
@dt_compra datetime NULL,
@des_notafiscal varchar(100) NULL,                      
@quantidade INT NULL,    
@des_caminhoAnexo varchar(5000) NULL,
@cod_produto int NULL            
       
AS                          
                   
/**************************************************************************                      
      
***************************************************************************/                      
                    
SET NOCOUNT ON                          
SET TRANSACTION ISOLATION LEVEL READ UNCOMMITTED                          
                          
BEGIN                          
      
INSERT dbo.NotaFiscal VALUES(@des_cnpj,@cod_canalcompra,@dt_compra, @des_notafiscal, @quantidade, @des_caminhoAnexo, @cod_produto, GETDATE(), null, 1)      
        
end     
