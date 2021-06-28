SELECT * FROM TB_Contatos 
SELECT * FROM TB_Tarefas

SELECT
                [ID],
                [NOME],
                [EMAIL],
                [TELEFONE],
                [EMPRESA],
                [CARGO] 
            FROM TB_Contatos
            ORDER BY  
                     [CARGO];