<?php

    $method = $_SERVER['REQUEST_METHOD'];
    
	$conexao = mysqli_connect("localhost","u522997124_root","craft127ca","u522997124_app"); 
	if (!$conexao)
		die ("Erro de conexão com localhost, o seguinte erro ocorreu -> ".mysqli_error());

	$banco = mysqli_select_db($conexao,"u522997124_app");
	if (!$banco)
		die ("Erro de conexão com banco de dados, o seguinte erro ocorreu -> ".mysqli_error());
		
	
	if($method == 'POST'){

        $nome = $_POST['nome'];
            
        $validade = $_POST['validade']; 
        $date = date('Y-m-d',strtotime($_POST['validade']));
            
        $percent = $_POST['percent']; 
        $cnpj = $_POST['cnpj']; 
        $IdCupom = $_POST['IdCupom']; 

		$query = "UPDATE `cupom` SET `nome`= '$nome', `validade`= '$date', `percent`= '$percent' 
            WHERE `cod` = '$IdCupom' AND `cnpj` = '$cnpj' ";
            
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