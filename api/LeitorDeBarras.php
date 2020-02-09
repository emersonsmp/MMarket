<?php
    $method = $_SERVER['REQUEST_METHOD'];
    
    if($method == 'GET')
	    $id = isset($_GET['id']) ? $_GET['id'] : '';
	
	if($method == 'POST')
	    $id = isset($_POST['id']) ? $_POST['id'] : '';
	

	$conexao = mysqli_connect("localhost","u522997124_root","craft127ca","u522997124_app"); 
	if (!$conexao)
		die ("Erro de conexão com localhost, o seguinte erro ocorreu -> ".mysqli_error());

	$banco = mysqli_select_db($conexao,"u522997124_app");
	if (!$banco)
		die ("Erro de conexão com banco de dados, o seguinte erro ocorreu -> ".mysqli_error());

	
        $EstaNaPrateleira = false;
	    $CodigoBarra = $_GET['CodigoBarra'];
		$cnpj = $_GET['cnpj'];
		
		$query = "SELECT * FROM `prateleira` WHERE `cod_barra` = '$CodigoBarra'  AND `cnpj` = '$cnpj' ";

		$result = mysqli_query($conexao, $query);
		if (!$result)
			"Erro de conexão com banco de dados, o seguinte erro ocorreu -> ";	
    
    	$resposta = $result->fetch_assoc();
        
        if($resposta != null){
			$EstaNaPrateleira = true;						
		}

		$query = "SELECT * FROM `produto` WHERE `cod_barra` = '$CodigoBarra' ";
		$result = mysqli_query($conexao, $query);
		if (!$result)
		    "Erro de conexão com banco de dados, o seguinte erro ocorreu -> ";
		
		$resposta = $result->fetch_assoc();
		
		$return = array('InDB'=>$EstaNaPrateleira,'produto'=> $resposta );
		echo json_encode($return);
		
?>