# Clube da Leitura

## Projeto

Desenvolvido durante o curso Fullstack da [Academia do Programador](https://www.academiadoprogramador.net) 2024

---
## Descrição

Gustavo tem uma coleção grande de revistas em quadrinhos. Por isso, resolveu
emprestar para os amigos. Assim foi criado o Clube da Leitura.

Mas para não perder nenhuma revista, seu pai contratou os alunos da Academia do
Programador 2024 para fazer uma aplicação que cadastra as revistas e controla os
empréstimos.

## Funcionalidades

1. O cadastro do **Amigo** consiste de:
	- nome
	- nome do responsável
	- telefone
	- endereço

	```
	1. Os amigos têm a possibilidade de receber Multas
	2. Visualizar amigos com Multas em aberto
	3. Não pode emprestar para amigos que tem Multas em aberto
	4. Quitar Multas
	```

2. Para ter mais controle sobre a devolução das revistas, Gustavo quer ter a possibilidade de cadastrar Caixas de Revistas.
					
	Para cada **Caixa**, deverá ser cadastrado:

	- uma etiqueta
	- a cor da caixa
	- quantidade de Dias de Empréstimo revistas
	- Ex: Caixa “Novidade” pode ser emprestada apenas por 3 dias

3. Para cada **Revista**, deverá ser cadastrado:
	- o título da revista
	- o número da edição
	- o ano da revista
	- a caixa onde está guardada


4. Para cada **Empréstimo** cadastram-se:
	- o amigo que pegou a revista
	- qual foi a revista emprestada
	- a data do empréstimo
	- a data de devolução
	- status indicando se foi concluído

	```
	1. Cada amigo só pode pegar uma revista por empréstimo.
	2. Mensalmente Gustavo verifica os empréstimos realizados no mês e diariamente os empréstimos que estão em aberto.
	3. Calcular data de Devolução baseando-se na Caixa da Revista
	4. Cobrar Multa para Devoluções atrasadas
	```

5. Nossos amigos querem ter a possibilidade de cadastrar uma **Reserva** para as Revistas.
	- É válida apenas por 2 dias
	- Passados 2 dias ela expira
	- Mesmos campos do empréstimo (amigo, revista)
	- A partir da tela de reservas, já poderá fazer empréstimos
	- status indicando se está expirada