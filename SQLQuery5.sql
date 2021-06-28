SELECT * FROM TB_Contatos
SELECT * FROM TB_Compromisso

INSERT INTO TB_Compromisso
            (
	            [Assunto],
	            [Local],
	            [Data_Compromisso],
                [Hora_Inicio],
                [Hora_Termino],
                [Id_Contato]
            )
            VALUES
            (
	            'Palestra',
	            'Bar do Gordo',
	            '2021/05/01',
                '15:00',
                '16:00',
                5
            )