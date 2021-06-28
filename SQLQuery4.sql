SELECT * FROM TB_Contatos
SELECT * FROM TB_Compromisso
SELECT
            [TB_Compromisso].Id,
            [ASSUNTO],
            [LOCAL],
            [DATA_COMPROMISSO],
            [HORA_INICIO],
            [HORA_TERMINO],
            [TB_Contatos].NOME

            FROM 
            
            TB_Compromisso INNER JOIN
            TB_Contatos ON [TB_Compromisso].Id_Contato = [TB_Contatos].id

            WHERE DATEDIFF(DAY,[DATA_COMPROMISSO] , GETDATE()) >=7