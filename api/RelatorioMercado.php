<?php

	$method = $_SERVER['REQUEST_METHOD'];
	
	//CABECALHO DA CONEXAO
	$conexao = mysqli_connect("localhost","u522997124_root","craft127ca","u522997124_app"); 
	if (!$conexao)
		die ("Erro de conexão com localhost, o seguinte erro ocorreu -> ".mysqli_error());

	$banco = mysqli_select_db($conexao,"u522997124_app");
	if (!$banco)
		die ("Erro de conexão com banco de dados, o seguinte erro ocorreu -> ".mysqli_error());

        
        //RETORNA DUAS RESPOSTAS EM APENAS UM JSON
        //RETORNA VIEW + TOTAL GANHO + PEDIDOS | PARA TELA INICIAL RELATORIOS
            
        $status = $_GET['status'];
        $cnpj   = $_GET['cnpj'];
            
            
        //QUERY VIEW E TOTAL
        $query = "Select sum(total) AS Total, views FROM pedido join mercado 
        on mercado.cnpj = '$cnpj' 
        WHERE EXISTS (SELECT DISTINCT pedido_item.Pedido_idpedido FROM pedido_item 
        WHERE pedido_item.Item_mercado_cnpj = '$cnpj') 
        AND `FlagEntrega` = '$status'";
            
        $result = mysqli_query($conexao, $query);
	    if (!$result)
	    	"Erro de conexão com banco de dados, o seguinte erro ocorreu -> ";
        $r = mysqli_fetch_assoc($result);
            
            
            
        //QUERY PEDIDOS
        $query = "SELECT DISTINCT pedido.idpedido,pedido.total, pedido.DataVenda, pedido.DataEntrega, 
	            pedido.Troco, pedido.TipoPagamento, pedido.Cliente_cpf
                FROM pedido JOIN pedido_item 
                ON pedido.idpedido = pedido_item.Pedido_idpedido 
                WHERE pedido.FlagEntrega = '$status' AND pedido_item.Item_mercado_cnpj = '$cnpj' ";
        
	
	   $result = mysqli_query($conexao, $query);
	   if (!$result)
	    "Erro de conexão com banco de dados, o seguinte erro ocorreu -> ";
	    	    
        $rows = array();
	
	    $rows['Totalganho'] = $r['Total'];
	    $rows['views'] = $r['views'];
    	$rows['TotalPedidos'] = mysqli_num_rows($result);
	
        while($r = mysqli_fetch_assoc($result)) {
            $rows['pedidos'][] = $r;
        }
        
        echo json_encode($rows);

?>