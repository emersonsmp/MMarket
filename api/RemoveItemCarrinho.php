<?php

    $method = $_SERVER['REQUEST_METHOD'];

    $conexao = mysqli_connect("localhost","u522997124_root","craft127ca","u522997124_app"); 
	if (!$conexao)
		die ("Erro de conexão com localhost, o seguinte erro ocorreu -> ".mysqli_error());

	$banco = mysqli_select_db($conexao,"u522997124_app");
	if (!$banco)
        die ("Erro de conexão com banco de dados, o seguinte erro ocorreu -> ".mysqli_error());
    

    //REMOVE ITEM DO CARRINHO
    if($method == 'POST'){
        
        $itemid = $_POST['itemid'];
            
        $query = "DELETE FROM `pedido_item` WHERE `Item_id` = '$itemid' ";
        $result = mysqli_query($conexao, $query);
        if (!$result){
            "Erro de conexão com banco de dados, o seguinte erro ocorreu -> ";
        }
			    
        $query = "DELETE FROM `item` WHERE `id` = '$itemid' ";
        $result = mysqli_query($conexao, $query);
        
        if (!$result){
            "Erro de conexão com banco de dados, o seguinte erro ocorreu -> ";
        }
    }
    
    
    if($method == 'GET'){
    }
?>