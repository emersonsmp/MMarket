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



    //GET PRODUTO PELO CODIGO DE BARRA
    if($method == "GET"){
       $CodigoBarra = $_GET['CodigoBarra']; 
	    $query = "SELECT * FROM `produto` WHERE `cod_barra` = '$CodigoBarra'";

	    $result = mysqli_query($conexao, $query);
	    if (!$result)
		    "Erro de conexão com banco de dados, o seguinte erro ocorreu -> ";	
    
        $resposta = $result->fetch_assoc();
        echo json_encode($resposta); 
    }
	
    
    
    //UPDATE PRECO OU QUANTIDADE DE PRODUTO
	if($method == 'POST'){
	    
	    $cnpj = $_POST['cnpj'];
		$CodigoBarra = $_POST['CodigoBarra'];
		
		$quantidade = $_POST['quant'];
		$quant = (int)$quantidade;
		
		$precoStr = $_POST['preco'];
		$preco = (float)$precoStr;
	    
	    $query = "UPDATE `prateleira` SET `quantidade`= $quant,`preco`= $preco 
	    WHERE `cnpj` = '$cnpj' AND `cod_barra` = '$CodigoBarra' ";
	    
	    $result = mysqli_query($conexao, $query);
		if (!$result){
		    
		    $resposta = array('sucess'=>'error', 'message'=>'400');
		    echo json_encode($resposta);
		    
		}else{
		    
		    $resposta = array('sucess'=>'sucess', 'message'=>'200');
		    echo json_encode($resposta);
		}
	    
	    
	}

	
?>