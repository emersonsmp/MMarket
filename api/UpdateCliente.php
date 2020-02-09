<?php

	//VAI RECEBER O METODO EX: GET, POST, DELETE;
	$method = $_SERVER['REQUEST_METHOD'];
	
	$id = isset($_POST['id']) ? $_POST['id'] : '';

	
	//CABECALHO DA CONEXAO
	$conexao = mysqli_connect("localhost","u522997124_root","craft127ca","u522997124_app"); 
	if (!$conexao)
		die ("Erro de conexão com localhost, o seguinte erro ocorreu -> ".mysqli_error());

	$banco = mysqli_select_db($conexao,"u522997124_app");
	if (!$banco)
		die ("Erro de conexão com banco de dados, o seguinte erro ocorreu -> ".mysqli_error());
	
	
	//UPDATE CLIENTE
	if($method === 'POST'){
		
		$cpf       =       $_POST['cpf'];
		$nome      =      $_POST['nome'];
		$sobrenome = $_POST['sobrenome'];
		$endereco  =  $_POST['endereco'];
		$numero    =    $_POST['numero'];
		$email     =     $_POST['email'];
        $senha     =     $_POST['senha'];
    
        $query = "UPDATE `cliente` SET `cpf`= '$cpf',`nome`= '$nome',`sobrenome`= '$sobrenome',`endereco`= '$endereco',
        `numero`= '$numero',`email`= '$email',`senha`= '$senha' WHERE cpf = '$cpf'";

		$conect = mysqli_query($conexao, $query);
		if (!$conect){ 
			"Erro de conexão com banco de dados, o seguinte erro ocorreu -> "; 
		}else{
			$true = array('success' => 'true', 'message' => "Usuario Atualizado");
			echo json_encode($true);
		}	
	}
	
?>