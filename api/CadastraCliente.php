<?php

	//VAI RECEBER O METODO EX: GET, POST, DELETE;
	$method = $_SERVER['REQUEST_METHOD'];
	
	//CABECALHO DA CONEXAO---------------------------------------------------------------------
	$conexao = mysqli_connect("localhost","u522997124_root","craft127ca","u522997124_app"); 
	if (!$conexao)
		die ("Erro de conexão com localhost, o seguinte erro ocorreu -> ".mysqli_error());

	$banco = mysqli_select_db($conexao,"u522997124_app");
	if (!$banco)
		die ("Erro de conexão com banco de dados, o seguinte erro ocorreu -> ".mysqli_error());
	//-----------------------------------------------------------------------------------------
	
	
	//CADASTRA CLIENTE
	if($method === 'POST'){
		
		$cpf       =       $_POST['cpf'];
		$nome      =      $_POST['nome'];
		$sobrenome = $_POST['sobrenome'];
		$endereco  =  $_POST['endereco'];
		$numero    =    $_POST['numero'];
		$email     =     $_POST['email'];
		$senha     =     $_POST['senha'];
	
		$query = "INSERT INTO `cliente`(`cpf`, `nome`, `sobrenome`, `endereco`, `numero`, `email`, `senha`) 
		VALUES ('$cpf', '$nome', '$sobrenome', '$endereco', '$numero', '$email', '$senha')";

		$conect = mysqli_query($conexao, $query);
		if (!$conect){ 
			"Erro de conexão com banco de dados, o seguinte erro ocorreu -> "; 
		}else{
			$true = array('success' => 'true', 'message' => "Registered user");	
			echo json_encode($true);
		}
		
	}
?>