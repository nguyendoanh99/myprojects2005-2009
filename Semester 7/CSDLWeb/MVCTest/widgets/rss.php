<h4>phpvn.org 5 latest posts</h4>
<?php
require_once 'Zend/Feed.php';

// Fetch the latest Slashdot headlines
try {
    $phpvnRss = Zend_Feed::import('http://www.phpvn.org/index.php?action=.xml&type=rss');
} catch (Zend_Feed_Exception $e) {
    // feed import failed
    echo "Exception caught importing feed: {$e->getMessage()}\n";
    exit;
}

// Initialize the channel data array
$channel = array(
    'title'       => $phpvnRss->title(),
    'link'        => $phpvnRss->link(),
    'description' => $phpvnRss->description(),
    'items'       => array()
    );

// Loop over each channel item and store relevant data
foreach ($phpvnRss as $item) {
    $channel['items'][] = array(
        'title'       => $item->title(),
        'link'        => $item->link(),
        'description' => $item->description()
        );
}

if (count($channel['items']))
{
	echo "<ul>";
	for ($i = 0; $i < 5 && $i < count($channel['items']); $i++)
	{
		$item = $channel['items'][$i];
		echo '<li><a href="' . $item['link'] . '" target="_blank">'.$item['title'].'</a></li>';
	}
	echo "</ul>";
}
?>