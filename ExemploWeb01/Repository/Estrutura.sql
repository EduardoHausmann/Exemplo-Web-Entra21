DROP TABLE IF EXISTS estoques;
CREATE TABLE estoques(
	id INT PRIMARY KEY IDENTITY(1,1),
	nome VARCHAR(100),
	valor DECIMAL(8,2),
	quantidade INt
);