<?php
	//VAI RECEBER O METODO EX: GET, POST, DELETE;
	$method = $_SERVER['REQUEST_METHOD'];
	
	//CABECALHO DA CONEXAO
	$conexao = mysqli_connect("localhost","u522997124_root","craft127ca","u522997124_app"); 
	if (!$conexao)
		die ("Erro de conexão com localhost, o seguinte erro ocorreu -> ".mysqli_error());

	$banco = mysqli_select_db($conexao,"u522997124_app");
	if (!$banco)
		die ("Erro de conexão com banco de dados, o seguinte erro ocorreu -> ".mysqli_error());
	
	
	//LOGIN DO USUARIO
	if($method === 'POST'){
		
		$email = isset($_POST['email']) ? $_POST['email'] : '';
	    $senha = isset($_POST['senha']) ? $_POST['senha'] : '';
		
		
		$query = "SELECT * FROM `cliente` WHERE `email` = '$email' AND `senha` = '$senha' ";
		
		$result = mysqli_query($conexao, $query);
		if (!$result) "Erro de conexão com banco de dados, o seguinte erro ocorreu -> ";
		
		$tupla = $result->fetch_assoc();
		echo json_encode($tupla);
	}
	
?>