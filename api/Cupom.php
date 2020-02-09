<?php

    $method = $_SERVER['REQUEST_METHOD'];
    
	$conexao = mysqli_connect("localhost","u522997124_root","craft127ca","u522997124_app"); 
	if (!$conexao)
		die ("Erro de conexão com localhost, o seguinte erro ocorreu -> ".mysqli_error());

	$banco = mysqli_select_db($conexao,"u522997124_app");
	if (!$banco)
		die ("Erro de conexão com banco de dados, o seguinte erro ocorreu -> ".mysqli_error());
		
	//GET CUPONS
	if($method == 'GET'){
	    
	    $cnpj = $_GET['cnpj']; 
	    
		$query = "SELECT * FROM `cupom` WHERE `cnpj` = '$cnpj'";
		$result = mysqli_query($conexao, $query);
		if (!$result)
			"Erro de conexão com banco de dados, o seguinte erro ocorreu -> ";
    	
    	$rows = array();
        while($r = mysqli_fetch_assoc($result)) {
            $rows['cupons'][] = $r;
        }
        
        echo json_encode($rows);
	    
	}
	
	//CRIA CUPOM
	if($method == 'POST'){

        $nome = $_POST['nome'];
        $validade = $_POST['validade']; 
        $percent = $_POST['percent']; 
        $cnpj = $_POST['cnpj']; 

		$query = "INSERT INTO `cupom`(`nome`, `validade`, `percent`, `cnpj`) 
		    VALUES ('$nome','$validade','$percent','$cnpj')";
            
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